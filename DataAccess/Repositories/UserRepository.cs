using Microsoft.EntityFrameworkCore;
using SofTk_TechOil.DataAccess.Repositories.Interfaces;
using SofTk_TechOil.DTOs;
using SofTk_TechOil.Entities;
using SofTk_TechOil.Helper;

namespace SofTk_TechOil.DataAccess.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(AppDbContext context) : base(context)
        {
        }

        public override async Task<bool> UpdateAsync(User updateUser)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == updateUser.Id);
            if (user == null) { return false; }

            user.CodUsuario = updateUser.CodUsuario;
            user.Nombre = updateUser.Nombre;
            user.DNI = updateUser.DNI;
            user.RoleId = updateUser.RoleId;
            user.Activo = updateUser.Activo;
            user.Password = PassEncryptHelper.CreatePass(updateUser.Password, updateUser.CodUsuario);

            _context.Users.Update(user);
            return true;
        }

        public override async Task<bool> DeleteAsync(int id)
        {
            var user = await _context.Users.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (user != null)
            {
                user.Activo = false;
                _context.Users.Update(user);
            }

            return true;
        }

        public async Task<User?> AuthenticateCredentials(AuthUserDto dto)
        {           
            string encryptedPassword = PassEncryptHelper.CreatePass(dto.Password, dto.CodUsuario);
      
            return await _context.Users
                .Include(x => x.Role)
                .SingleOrDefaultAsync(x => x.CodUsuario == dto.CodUsuario && x.Password == encryptedPassword);
           // return await _context.Users.Include(x => x.Role).SingleOrDefaultAsync(x => x.CodUsuario == dto.CodUsuario && x.Password == PassEncryptHelper.CreatePass(dto.Password, dto.CodUsuario));
        }

        public async Task<bool> UserEx(int CodUsuario)
        {
            return await _context.Users.AnyAsync(x => x.CodUsuario == CodUsuario);
        }
    }
}
