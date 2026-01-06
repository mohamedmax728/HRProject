using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Modules.TaskManagement.Application.Contracts.Persistence;
using Modules.TaskManagement.Domain.Entities;

namespace Modules.TaskManagement.Persistence.Repositories
{
    internal class ProjectRepository : BaseRepository<Project>, IProjectRepository
    {
        public ProjectRepository(DbContext context, IConfigurationProvider mapperConfig) : base(context, mapperConfig)
        {
        }
    }
}
