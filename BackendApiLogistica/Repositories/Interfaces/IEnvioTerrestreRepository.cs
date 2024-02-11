using System.Collections.Generic;
using System.Threading.Tasks;
using BackendApiLogistica.Data.Models;

namespace BackendApiLogistica.Repositories.Interfaces
{
    public interface IEnvioTerrestreRepository
    {
        Task<IEnumerable<EnvioTerrestre>> GetAllAsync();
        Task<EnvioTerrestre> GetByIdAsync(int envioTerrestreId);
        Task<EnvioTerrestre> CreateAsync(EnvioTerrestre envioTerrestre);
        Task UpdateAsync(EnvioTerrestre envioTerrestre);
        Task DeleteAsync(int envioTerrestreId);
    }
}
