using CoreDDD.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ValueObjects.Rules
{
    public class LatitudRule : IBusinessRule
    {
        private readonly decimal _value;

        public LatitudRule(decimal value)
        {
            _value = value;
        }

        public string Message => "Latitude value must be between -90 and 90";

        public bool IsBroken()
        {
            return _value < -90 || _value > 90;
        }
    }
}
