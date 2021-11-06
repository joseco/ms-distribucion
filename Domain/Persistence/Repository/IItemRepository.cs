using CoreDDD.Core;
using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Persistence.Repository
{
    public interface IItemRepository : IRepository<Item, Guid>
    {
        Task Insert(Item item);

        Task<Item> GetItemByCode(string code);


        Task<ICollection<Item>> GetItems();
    }
}
