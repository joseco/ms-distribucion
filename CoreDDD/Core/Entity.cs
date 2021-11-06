using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreDDD.Core
{
    public abstract class Entity<T> : DomainObject
    {
        public T Id { get; protected set; }
    }
}
