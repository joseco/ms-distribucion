
using CoreDDD.Core;
using CoreDDD.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Domain.Test
{
    public class TestValueObjects
    {
        [Fact]
        public void TestInvalidGps()
        {
            Assert.Throws<BusinessRuleValidationException>(() =>
           {
               GpsPositionValue posicion = new GpsPositionValue(230, 120);
           });
            Assert.Throws<BusinessRuleValidationException>(() =>
            {
                GpsPositionValue posicion = new GpsPositionValue(-230, -120);
            });
        }

        [Fact]
        public void TestValidGps()
        {
            decimal latitud = -17.7619302m;
            decimal longitud = -63.1678671m;

            GpsPositionValue posicion = new GpsPositionValue(latitud, longitud);
            Assert.Equal(latitud, posicion.Latitud, 1);
            Assert.Equal(longitud, posicion.Longitud, 1);


        }
    }
}
