using CoreDDD.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CoreDDD.Rules
{
    public class StringOnlyLettersRule : IBusinessRule
    {
        public readonly string _value;

        public StringOnlyLettersRule(string value)
        {
            _value = value;
        }
        public string Message => "Value cannot contains numbers or special charactes";

        public bool IsBroken()
        {
            return Regex.IsMatch(_value, "\\d");
        }
    }
}
