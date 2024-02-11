using BackendApiLogistica.Data.Models;
using BackendApiLogistica.Data;
using BackendApiLogistica.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BackendApiLogistica.Repositories
{
    public class ProductoRepository : IProductoRepository
    {
        private readonly GestionLogisticaContext _context;

        public ProductoRepository(GestionLogisticaContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Producto>> GetAllAsync()
        {
            return await _context.Productos.ToListAsync();
        }

        public async Task<Producto> GetByIdAsync(int productoId)
        {
            return await _context.Productos.FindAsync(productoId);
        }

        public async Task<Producto> CreateAsync(Producto producto)
        {
            _context.Productos.Add(producto);
            await _context.SaveChangesAsync();
            return producto;
        }

        public async Task UpdateAsync(Producto producto)
        {
            _context.Entry(producto).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int productoId)
        {
            var producto = await _context.Productos.FindAsync(productoId);
            if (producto != null)
            {
                _context.Productos.Remove(producto);
                await _context.SaveChangesAsync();
            }
        }
    }
}
