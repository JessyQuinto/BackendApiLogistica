using System.Collections.Generic;
using System.Threading.Tasks;
using BackendApiLogistica.Data.Models;

namespace BackendApiLogistica.Repositories.Interfaces
{

    public interface IBodegaRepository
    {
        Task<IEnumerable<Bodega>> GetAllAsync();
        Task<Bodega> GetByIdAsync(int bodegaId);
        Task<Bodega> CreateAsync(Bodega bodega);
        Task UpdateAsync(Bodega bodega);
        Task DeleteAsync(int bodegaId);
    }

}
