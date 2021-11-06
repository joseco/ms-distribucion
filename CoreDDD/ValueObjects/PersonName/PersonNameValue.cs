using CoreDDD.Core;
using CoreDDD.Rules;
using CoreDDD.ValueObjects.PersonName.Rules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreDDD.ValueObjects.PersonName
{
    public class PersonNameValue : ValueObject
    {
        public string Value { get; private set; }

        public PersonNameValue(string value)
        {
            CheckRule(new NotNullRule(value));
            CheckRule(new StringOnlyLettersRule(value));
            CheckRule(new PersonNameLenghtRule(value));
            Value = value;
        }

        #region Conversion

        public static implicit operator string(PersonNameValue value) => value.Value;

        public static implicit operator PersonNameValue(string value) => value == null ? null : new PersonNameValue(value);

        #endregion

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Value;
        }
    }
}
