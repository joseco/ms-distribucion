using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreDDD.Core
{
    public interface IRepository<T, TKEY> where T : AggregateRoot<TKEY>
    {
        Task<T> GetById(TKEY id);
    }
}
