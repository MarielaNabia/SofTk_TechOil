using Microsoft.EntityFrameworkCore;
using SofTk_TechOil.DataAccess.Repositories.Interfaces;
using SofTk_TechOil.Entities;
using static SofTk_TechOil.Entities.Project;

namespace SofTk_TechOil.DataAccess.Repositories
{
    public class ProjectRepository : Repository<Project>, IProjectRepository
    {
        public ProjectRepository(AppDbContext context) : base(context)
        {
        }
        public async Task<List<Project>> GetAllAsync()
        {
            return await _context.Projects.ToListAsync();
        }
        public async Task<List<Project>> GetEstadoProjectsAsync(EstadoTrabajo estado)
        {
            return await _context.Projects
                .Where(p => p.Estado == estado)
                .ToListAsync();
        }

        public async Task<Project> GetByIdAsync(int id)
        {
            return await _context.Projects.FindAsync(id);
        }

        public async Task<bool> CreateAsync(Project entity)
        {
            try
            {
                _context.Projects.Add(entity);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> UpdateAsync(Project entity)
        {
            try
            {
                _context.Projects.Update(entity);
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
                var projectToDelete = await _context.Projects.FindAsync(id);
                if (projectToDelete != null)
                {
                    projectToDelete.Activo = false;  
                    _context.Projects.Update(projectToDelete);
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

