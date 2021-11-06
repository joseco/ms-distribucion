using CoreDDD.Core;
using CoreDDD.Rules;
using CoreDDD.ValueObjects;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Domain.Model
{
    public class Viaje : AggregateRoot<Guid>
    {
        public Guid OrdenEntregaId { get; private set; }

        public DateTime FechaProgramacion { get; private set; }
        public DateTime? FechaInicio { get; private set; }
        public DateTime? FechaFin { get; private set; }

        public ICollection<ItemViaje> ItemsViaje { get; private set; }
        public ICollection<SeguimientoViajeGps> SeguimientoGps { get; private set; }

        public Viaje(OrdenEntrega orden, DateTime fechaProgramacion,
            ICollection<ItemViaje> itemsEntrega)
        {

            CheckRule(new NotNullRule(orden));
            CheckRule(new NotNullRule(itemsEntrega));

            if(fechaProgramacion < DateTime.Today)
            {
                throw new BusinessRuleValidationException("La fecha de programacion no puede ser una fecha pasada");
            }

            OrdenEntregaId = orden.Id;
            FechaProgramacion = fechaProgramacion;

            ItemsViaje = itemsEntrega;
            SeguimientoGps = new List<SeguimientoViajeGps>();
        }

        protected Viaje()
        {

        }

        public void AgregarPosicionSeguimiento(decimal latitud, decimal longitud)
        {
            GpsPositionValue posicion = new GpsPositionValue(latitud, longitud);
            SeguimientoViajeGps item = new SeguimientoViajeGps(this, posicion);

            SeguimientoGps.Add(item);
        }

    }
}
