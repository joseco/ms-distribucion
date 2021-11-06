using CoreDDD.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreDDD.ValueObjects.PersonName.Rules
{
    public class PersonNameLenghtRule : IBusinessRule
    {
        public readonly string _value;

        public PersonNameLenghtRule(string value)
        {
            _value = value;
        }

        public string Message => "Person names cannot be less than 200 characters";

        public bool IsBroken()
        {
            return _value.Length > 200;
        }
    }
}
