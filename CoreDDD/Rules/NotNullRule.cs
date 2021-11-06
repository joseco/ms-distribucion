using CoreDDD.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreDDD.Rules
{
    public class NotNullRule : IBusinessRule
    {
        public readonly object _value;

        public NotNullRule(object value)
        {
            _value = value;
        }
        public string Message => "Value cannot contains numbers or special charactes";

        public bool IsBroken()
        {
            return _value == null;
        }
    }
}
