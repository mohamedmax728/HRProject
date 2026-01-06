using Modules.TaskManagement.Domain.Entities;

namespace Modules.TaskManagement.Application.Contracts.Persistence
{
    public interface IProjectRepository : IAsyncRepository<Project>
    {
    }
}
