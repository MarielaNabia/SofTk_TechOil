using Microsoft.EntityFrameworkCore;
using SofTk_TechOil.DataAccess.Repositories.Interfaces;
using SofTk_TechOil.Entities;

namespace SofTk_TechOil.DataAccess.Repositories
{
    public class RoleRepository : Repository<Role>, IRoleRepository
    {

        public RoleRepository(AppDbContext context) : base(context)
        {

        }

        public override async Task<bool> UpdateAsync(Role updateRole)
        {
            var Role = await _context.Roles.FirstOrDefaultAsync(x => x.Id == updateRole.Id);
            if (Role == null) { return false; }

            Role.Name = updateRole.Name;
            Role.Description = updateRole.Description;
            Role.Activo = updateRole.Activo;

            _context.Roles.Update(Role);
            return true;
        }

        public override async Task<bool> DeleteAsync(int id)
        {
            var Role = await _context.Roles.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (Role != null)
            {
                _context.Roles.Remove(Role);
            }

            return true;
        }

    }
}
