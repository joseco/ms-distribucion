using CoreDDD.Core;
using Domain.ValueObjects.Rules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ValueObjects
{
    public class PosicionGps : ValueObject
    {
        public decimal Latitud { get; private set; }
        public decimal Longitud { get; private set; }

        public PosicionGps(decimal latitud, decimal longitud)
        {
            CheckRule(new LatitudRule(latitud));
            CheckRule(new LongitudRule(longitud));
            Latitud = latitud;
            Longitud = longitud;
        }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Latitud;
            yield return Longitud;
        }
    }
}
