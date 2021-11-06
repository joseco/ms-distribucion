using CoreDDD.Core;
using CoreDDD.Rules;
using CoreDDD.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class SeguimientoViajeGps : Entity<Guid>
    {
        public Viaje Viaje { get; set; }
        public Guid ViajeId { get; set; }

        public DateTime FechaHora { get; set; }
        public GpsPositionValue Ubicacion { get; set; }

        public SeguimientoViajeGps(Viaje objViaje, GpsPositionValue ubicacion)
        {
            CheckRule(new NotNullRule(objViaje));
            CheckRule(new NotNullRule(ubicacion));

            Id = Guid.NewGuid();
            Viaje = objViaje;
            ViajeId = Viaje.Id;
            FechaHora = DateTime.Now;
            Ubicacion = ubicacion;
        }

        protected SeguimientoViajeGps()
        {

        }

    }
}
