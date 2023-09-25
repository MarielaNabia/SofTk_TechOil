using Microsoft.EntityFrameworkCore;
using SofTk_TechOil.DataAccess.Repositories.Interfaces;
using SofTk_TechOil.Entities;

namespace SofTk_TechOil.DataAccess.Repositories
{
    public class ServiceRepository : Repository<Service>, IServiceRepository
    {
        public ServiceRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<List<Service>> GetAllAsync()
        {
            return await _context.Services.ToListAsync();
        }
        public async Task<List<Service>> GetActiveServicesAsync()
        {
            return await _context.Services
        .Where(s => s.Estado) // Filtrar por estado activo (true)
        .ToListAsync();
        }

        public async Task<Service> GetByIdAsync(int id)
        {
            return await _context.Services.FindAsync(id);
        }

        public async Task<bool> CreateAsync(Service entity)
        {
            try
            {
                _context.Services.Add(entity);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> UpdateAsync(Service entity)
        {
            try
            {
                _context.Services.Update(entity);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                var serviceToDelete = await _context.Services.FindAsync(id);
                if (serviceToDelete != null)
                {
                    serviceToDelete.Activo = false;
                    _context.Services.Update(serviceToDelete);
                    await _context.SaveChangesAsync();
                    return true;
                }
                return false; // El servicio no se encontró en la base de datos
            }
            catch (Exception)
            {
                return false; // Error durante la eliminación
            }
        }
    }
}
