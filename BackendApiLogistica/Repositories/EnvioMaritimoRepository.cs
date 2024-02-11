using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using BackendApiLogistica.Data;
using BackendApiLogistica.Data.Models;
using BackendApiLogistica.Repositories.Interfaces;

public class EnvioMaritimoRepository : IEnvioMaritimoRepository
{
    private readonly GestionLogisticaContext _context;

    public EnvioMaritimoRepository(GestionLogisticaContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<EnvioMaritimo>> GetAllAsync()
    {
        return await _context.EnviosMaritimos.Include(e => e.Cliente)
                                              .Include(e => e.Producto)
                                              .Include(e => e.Puerto)
                                              .ToListAsync();
    }

    public async Task<EnvioMaritimo> GetByIdAsync(int envioMaritimoId)
    {
        return await _context.EnviosMaritimos.FindAsync(envioMaritimoId);
    }

    public async Task<EnvioMaritimo> CreateAsync(EnvioMaritimo envioMaritimo)
    {
        _context.EnviosMaritimos.Add(envioMaritimo);
        await _context.SaveChangesAsync();
        return envioMaritimo;
    }

    public async Task UpdateAsync(EnvioMaritimo envioMaritimo)
    {
        _context.Entry(envioMaritimo).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int envioMaritimoId)
    {
        var envioMaritimo = await _context.EnviosMaritimos.FindAsync(envioMaritimoId);
        if (envioMaritimo != null)
        {
            _context.EnviosMaritimos.Remove(envioMaritimo);
            await _context.SaveChangesAsync();
        }
    }
}
