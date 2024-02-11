using BackendApiLogistica.Data.Models;

namespace BackendApiLogistica.Repositories.Interfaces
{
    public interface IProductoRepository
    {
        Task<IEnumerable<Producto>> GetAllAsync();
        Task<Producto> GetByIdAsync(int productoId);
        Task<Producto> CreateAsync(Producto producto);
        Task UpdateAsync(Producto producto);
        Task DeleteAsync(int productoId);
    }
}
