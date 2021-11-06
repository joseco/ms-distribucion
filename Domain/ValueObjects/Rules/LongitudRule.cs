using CoreDDD.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ValueObjects.Rules
{
    public class LongitudRule : IBusinessRule
    {
        private readonly decimal _value;

        public LongitudRule(decimal value)
        {
            _value = value;
        }

        public string Message => "Longitude value must be between -180 and 180";

        public bool IsBroken()
        {
            return _value < -180 || _value > 180;
        }
    }
}
