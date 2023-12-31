﻿using SofTk_TechOil.DataAccess.Repositories;

namespace SofTk_TechOil.Services
{
    public interface IUnitOfWork
    {
        public UserRepository UserRepository { get; }
        public RoleRepository RoleRepository { get; }
        public ServiceRepository ServiceRepository { get; }
        public ProjectRepository ProjectRepository { get; }
        public JobRepository JobRepository { get; }
        Task<int> Complete();
    }
}
