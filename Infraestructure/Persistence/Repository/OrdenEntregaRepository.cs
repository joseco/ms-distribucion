using Domain.Model;
using Domain.Persistence.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Infraestructure.Persistence.Repository
{
    public class OrdenEntregaRepository : IOrdenEntregaRepository
    {

        private readonly ApplicationDbContext _context;

        public OrdenEntregaRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        private IQueryable<OrdenEntrega> GetOrdenEntregaQueryable()
        {
            return _context.OrdenEntrega
                .Include(x => x.Items)
                .ThenInclude(x => x.Item);
        }

        public async Task<ICollection<OrdenEntrega>> GetAllOrdenEntrega()
        {
            IQueryable<OrdenEntrega> query = GetOrdenEntregaQueryable();
            return await query.ToListAsync();
        }

        public async Task<ICollection<OrdenEntrega>> GetAllOrdenEntrega(Expression<Func<OrdenEntrega, bool>> whereExpression)
        {
            IQueryable<OrdenEntrega> query = GetOrdenEntregaQueryable();
            return await query.Where(whereExpression).ToListAsync();
        }

        public async Task<OrdenEntrega> GetById(Guid id)
        {
            return await GetOrdenEntregaQueryable()
                .Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task Insert(OrdenEntrega ordenEntrega)
        {
            await _context.OrdenEntrega.AddAsync(ordenEntrega);
        }

        public void Update(OrdenEntrega ordenEntrega)
        {
            _context.OrdenEntrega.Update(ordenEntrega);
        }
    }
}
