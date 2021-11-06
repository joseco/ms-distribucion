using CoreDDD.Core;
using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Persistence.Repository
{
    public interface IOrdenEntregaRepository : IRepository<OrdenEntrega, Guid>
    {

        Task Insert(OrdenEntrega ordenEntrega);

        void Update(OrdenEntrega ordenEntrega);

        Task<ICollection<OrdenEntrega>> GetAllOrdenEntrega();

        Task<ICollection<OrdenEntrega>> GetAllOrdenEntrega(Expression<Func<OrdenEntrega, bool>> whereExpression);
        

    }
}
