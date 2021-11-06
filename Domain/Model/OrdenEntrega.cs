using CoreDDD.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreDDD.ValueObjects.PersonName;
using CoreDDD.Rules;
using Domain.Model.Rules;
using CoreDDD.ValueObjects;

namespace Domain.Model
{
    public class OrdenEntrega : AggregateRoot<Guid>
    {
        public DateTime FechaRegistro { get; private set; }
        public DateTime? FechaConsolidacion { get; private set; }
        public DateTime? FechaFinalizacion { get; private set; }
        public DateTime? FechaAnulacion { get; private set; }

        public EstadoOrdenEntrega Estado { get; private set; }

        public PersonNameValue Destinatario { get; private set; }
        public string Telefono { get; set; }

        public GpsPositionValue UbicacionGps { get; private set; }
        public string Direccion { get; private set; }

        public ICollection<ItemEntrega> Items { get; set; }


        public OrdenEntrega(string destinatario,
            string telefono,
            decimal latitud,
            decimal longitud,
            string direccion)
        {
            Destinatario = destinatario;

            CheckRule(new NotNullRule(telefono));
            Telefono = telefono;

            UbicacionGps = new GpsPositionValue(latitud, longitud);
            Direccion = direccion;

            Id = Guid.NewGuid();

            Items = new List<ItemEntrega>();
        }

        //EF or ORM
        protected OrdenEntrega() { }

        public void ConsolidarOrdenEntrega()
        {
            CheckRule(new ChangeOrderStatusRule(Estado, EstadoOrdenEntrega.ListoParaEntregar));
            FechaConsolidacion = DateTime.Now;
            Estado = EstadoOrdenEntrega.ListoParaEntregar;
        }

        public void FinalizarEntrega()
        {
            CheckRule(new ChangeOrderStatusRule(Estado, EstadoOrdenEntrega.ListoParaEntregar));
            FechaFinalizacion = DateTime.Now;
            Estado = EstadoOrdenEntrega.Finalizado;
        }

        public void AnularEntrega()
        {
            CheckRule(new ChangeOrderStatusRule(Estado, EstadoOrdenEntrega.Anulado));
            FechaAnulacion = DateTime.Now;
            Estado = EstadoOrdenEntrega.Anulado;
        }

        public Viaje ProgramarViaje(DateTime fechaProgramacion, ICollection<ItemViaje> items)
        {
            CheckRule(new ChangeOrderStatusRule(Estado, EstadoOrdenEntrega.EnProgreso));
            Viaje newViaje = new Viaje(this, fechaProgramacion, items);
            Estado = EstadoOrdenEntrega.EnProgreso;
            return newViaje;
        }
    }
}
