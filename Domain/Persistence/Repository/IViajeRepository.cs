using CoreDDD.Core;
using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Persistence.Repository
{
    public interface IViajeRepository : IRepository<Viaje, Guid>
    {
        Task<ICollection<Viaje>> GetViajeByOrdenEntregaId(Guid ordenEntregaId);

        Task<Viaje> GetViajeById(Guid viajeId);

        Task Insert(Viaje viaje);

        Task Update(Viaje viaje);

        Task Delete(Viaje viaje);

    }
}
