using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackendApiLogistica.Data.Models;
using BackendApiLogistica.Data; 


public class PuertoRepository : IPuertoRepository
{
    private readonly GestionLogisticaContext _context;

    public PuertoRepository(GestionLogisticaContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Puerto>> GetAllAsync()
    {
        return await _context.Puertos.ToListAsync();
    }

    public async Task<Puerto> GetByIdAsync(int puertoId)
    {
        return await _context.Puertos.FindAsync(puertoId);
    }

    public async Task<Puerto> CreateAsync(Puerto puerto)
    {
        _context.Puertos.Add(puerto);
        await _context.SaveChangesAsync();
        return puerto;
    }

    public async Task UpdateAsync(Puerto puerto)
    {
        _context.Entry(puerto).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int puertoId)
    {
        var puerto = await _context.Puertos.FindAsync(puertoId);
        if (puerto != null)
        {
            _context.Puertos.Remove(puerto);
            await _context.SaveChangesAsync();
        }
    }
}
