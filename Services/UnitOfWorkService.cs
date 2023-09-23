using SofTk_TechOil.DataAccess;
using SofTk_TechOil.DataAccess.Repositories;

namespace SofTk_TechOil.Services
{
    public class UnitOfWorkService : IUnitOfWork
    {
        private readonly AppDbContext _context;
        public UserRepository UserRepository { get; private set; }
        public RoleRepository RoleRepository { get; private set; }
        public ServiceRepository ServiceRepository { get; private set; }
        public ProjectRepository ProjectRepository { get; private set; }

        public UnitOfWorkService(AppDbContext context)
        {
            _context = context;
            UserRepository = new UserRepository(_context);
            RoleRepository = new RoleRepository(_context);
            ServiceRepository = new ServiceRepository(_context);
            ProjectRepository = new ProjectRepository(_context);
        }

        public Task<int> Complete()
        {
            return _context.SaveChangesAsync();
        }
    
    }
}
