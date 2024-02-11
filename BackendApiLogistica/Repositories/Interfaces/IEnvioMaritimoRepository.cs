using System.Collections.Generic;
using System.Threading.Tasks;
using BackendApiLogistica.Data.Models;

namespace BackendApiLogistica.Repositories.Interfaces
{
    public interface IEnvioMaritimoRepository
    {
        Task<IEnumerable<EnvioMaritimo>> GetAllAsync();
        Task<EnvioMaritimo> GetByIdAsync(int envioMaritimoId);
        Task<EnvioMaritimo> CreateAsync(EnvioMaritimo envioMaritimo);
        Task UpdateAsync(EnvioMaritimo envioMaritimo);
        Task DeleteAsync(int envioMaritimoId);
    }
}
