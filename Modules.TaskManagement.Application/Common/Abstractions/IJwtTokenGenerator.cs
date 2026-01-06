using Modules.TaskManagement.Domain.Entities;

namespace Modules.TaskManagement.Application.Common.Abstractions
{
    public interface IJwtTokenGenerator
    {
        string GenerateToken(User user);
    }
}
