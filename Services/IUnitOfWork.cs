using SofTk_TechOil.DataAccess.Repositories;

namespace SofTk_TechOil.Services
{
    public interface IUnitOfWork
    {
        public UserRepository UserRepository { get; }
        public RoleRepository RoleRepository { get; }
        public ServiceRepository ServiceRepository { get; }
        Task<int> Complete();
    }
}
