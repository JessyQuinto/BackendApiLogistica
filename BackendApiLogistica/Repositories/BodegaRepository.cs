using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using BackendApiLogistica.Data.Models;
using BackendApiLogistica.Data;
using BackendApiLogistica.Repositories.Interfaces;

public class BodegaRepository : IBodegaRepository
{
    private readonly GestionLogisticaContext _context;

    public BodegaRepository(GestionLogisticaContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Bodega>> GetAllAsync()
    {
        return await _context.Bodegas.ToListAsync();
    }

    public async Task<Bodega> GetByIdAsync(int bodegaId)
    {
        return await _context.Bodegas.FindAsync(bodegaId);
    }

    public async Task<Bodega> CreateAsync(Bodega bodega)
    {
        _context.Bodegas.Add(bodega);
        await _context.SaveChangesAsync();
        return bodega;
    }

    public async Task UpdateAsync(Bodega bodega)
    {
        _context.Entry(bodega).State = EntityState.Modified;
        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!BodegaExists(bodega.BodegaID))
            {
                return; // O manejar como prefieras, por ejemplo lanzando una excepción propia
            }
            else
            {
                throw;
            }
        }
    }

    public async Task DeleteAsync(int bodegaId)
    {
        var bodega = await _context.Bodegas.FindAsync(bodegaId);
        if (bodega != null)
        {
            _context.Bodegas.Remove(bodega);
            await _context.SaveChangesAsync();
        }
    }

    private bool BodegaExists(int bodegaId)
    {
        return _context.Bodegas.Any(e => e.BodegaID == bodegaId);
    }
}
