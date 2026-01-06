using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Modules.TaskManagement.Application.Contracts.Persistence;

namespace Modules.TaskManagement.Persistence.Repositories
{
    internal class TaskRepository : BaseRepository<Modules.TaskManagement.Domain.Entities.Task>, ITaskRepository
    {
        public TaskRepository(DbContext context, IConfigurationProvider mapperConfig) : base(context, mapperConfig)
        {
        }
    }
}
