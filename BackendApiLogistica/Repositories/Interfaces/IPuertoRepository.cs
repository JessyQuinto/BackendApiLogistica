using System.Collections.Generic;
using System.Threading.Tasks;
using BackendApiLogistica.Data.Models;

public interface IPuertoRepository
{
    Task<IEnumerable<Puerto>> GetAllAsync();
    Task<Puerto> GetByIdAsync(int puertoId);
    Task<Puerto> CreateAsync(Puerto puerto);
    Task UpdateAsync(Puerto puerto);
    Task DeleteAsync(int puertoId);
}
