using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackendApiLogistica.Data;
using BackendApiLogistica.Data.Models;
using BackendApiLogistica.Repositories.Interfaces;

public class EnvioTerrestreRepository : IEnvioTerrestreRepository
{
    private readonly GestionLogisticaContext _context;

    public EnvioTerrestreRepository(GestionLogisticaContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<EnvioTerrestre>> GetAllAsync()
    {
        return await _context.EnviosTerrestres.ToListAsync();
    }

    public async Task<EnvioTerrestre> GetByIdAsync(int envioTerrestreId)
    {
        return await _context.EnviosTerrestres.FindAsync(envioTerrestreId);
    }

    public async Task<EnvioTerrestre> CreateAsync(EnvioTerrestre envioTerrestre)
    {
        _context.EnviosTerrestres.Add(envioTerrestre);
        await _context.SaveChangesAsync();
        return envioTerrestre;
    }

    public async Task UpdateAsync(EnvioTerrestre envioTerrestre)
    {
        _context.Entry(envioTerrestre).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int envioTerrestreId)
    {
        var envioTerrestre = await _context.EnviosTerrestres.FindAsync(envioTerrestreId);
        if (envioTerrestre != null)
        {
            _context.EnviosTerrestres.Remove(envioTerrestre);
            await _context.SaveChangesAsync();
        }
    }
}
