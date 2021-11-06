using Domain.Model;
using Domain.Persistence.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Persistence.Repository
{
    public class ItemRepository : IItemRepository
    {
        private readonly ApplicationDbContext _context;

        public ItemRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Item> GetById(Guid id)
        {
            return await _context.Item.Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<Item> GetItemByCode(string code)
        {
            return await _context.Item
                .Where(x => x.Codigo.ToLower().Equals(code.ToLower()))
                .FirstOrDefaultAsync();
        }

        public async Task<ICollection<Item>> GetItems()
        {
            return await _context.Item.ToListAsync();
        }

        public async Task Insert(Item item)
        {            
            await _context.Item.AddAsync(item);
        }
    }
}
