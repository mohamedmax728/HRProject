using Modules.TaskManagement.Application.Features.Authentication.Dtos;
using Modules.TaskManagement.Application.Responses;

namespace Modules.TaskManagement.Application.Features.Authentication
{
    public interface IAuthenticationService
    {
        Task<BaseResponse<LoginResponse>> LoginAsync(LoginRequest request);
    }

}
