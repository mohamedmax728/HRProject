using Modules.TaskManagement.Application.Features.User.Dtos;
using Modules.TaskManagement.Application.Responses;

namespace Modules.TaskManagement.Application.Features.User
{
    public interface IUserService
    {
        Task<BaseResponse> Create(CreateUserRequest createUserRequest);
        Task<BaseResponse> Update(UpdateUserRequest updateUserRequest);
    }
}
