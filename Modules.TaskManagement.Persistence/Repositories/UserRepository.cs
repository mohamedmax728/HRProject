using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Modules.TaskManagement.Application.Contracts.Persistence;

namespace Modules.TaskManagement.Persistence.Repositories
{
    internal class UserRepository : BaseRepository<Modules.TaskManagement.Domain.Entities.User>, IUserRepository
    {
        public UserRepository(DbContext context, IConfigurationProvider mapperConfig) : base(context, mapperConfig)
        {
        }
    }
}
