using Modules.TaskManagement.Domain.Entities;

namespace Modules.TaskManagement.Application.Contracts.Persistence
{
    public interface IUserRepository : IAsyncRepository<User>
    {
    }
}
