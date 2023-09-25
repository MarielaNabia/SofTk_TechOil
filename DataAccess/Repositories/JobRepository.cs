using Microsoft.EntityFrameworkCore;
using SofTk_TechOil.DataAccess.Repositories.Interfaces;
using SofTk_TechOil.Entities;

namespace SofTk_TechOil.DataAccess.Repositories
{
    public class JobRepository : Repository<Job>, IJobRepository
    {
        public JobRepository(AppDbContext context) : base(context)
    {
    }
     
            public async Task<List<Job>> GetAllAsync()
            {

            // return await _context.Jobs.ToListAsync();
            return await _context.Jobs
             .Include(j => j.Project) // Incluye la relación con Project
             .Include(j => j.Service) // Incluye la relación con Service
             .ToListAsync();
        }         

            public async Task<Job> GetByIdAsync(int id)
            {
                return await _context.Jobs.FindAsync(id);
            }

            public async Task<bool> CreateAsync(Job entity)
            {
                try
                {
                    _context.Jobs.Add(entity);
                    await _context.SaveChangesAsync();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }

            public async Task<bool> UpdateAsync(Job entity)
            {
                try
                {
                    _context.Jobs.Update(entity);
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
                    var jobToDelete = await _context.Jobs.FindAsync(id);
                    if (jobToDelete != null)
                    {
                        jobToDelete.Activo = false;
                        _context.Jobs.Update(jobToDelete);
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

