using Modules.TaskManagement.Application.Common.Abstractions;
using Modules.TaskManagement.Application.Common.Helpers;
using Modules.TaskManagement.Application.Contracts.Persistence;
using Modules.TaskManagement.Application.Features.Authentication.Dtos;
using Modules.TaskManagement.Application.Responses;

namespace Modules.TaskManagement.Application.Features.Authentication
{
    public class AuthenticationService(
            IUserRepository userRepository,
            IJwtTokenGenerator jwtTokenGenerator) : IAuthenticationService
    {

        public async Task<BaseResponse<LoginResponse>> LoginAsync(LoginRequest request)
        {
            var user = await userRepository
                .GetAsync(u => u.Email == request.Email, u => u.Role);

            if (user == null ||
                !PasswordMaker.VerifyPassword(
                    request.Password,
                    user.PasswordHash,
                    user.PasswordSalt))
            {
                return new BaseResponse<LoginResponse>
                {
                    Success = false,
                    Message = "Invalid email or password"
                };
            }

            var token = jwtTokenGenerator.GenerateToken(user);

            return new BaseResponse<LoginResponse>
            {
                Success = true,
                Data = new LoginResponse
                {
                    Token = token,
                    ExpiresAt = DateTime.UtcNow.AddMinutes(60)
                }
            };
        }
    }
}
