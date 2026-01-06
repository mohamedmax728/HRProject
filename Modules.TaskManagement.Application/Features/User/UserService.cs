using AutoMapper;
using Modules.TaskManagement.Application.Common.Helpers;
using Modules.TaskManagement.Application.Contracts.Persistence;
using Modules.TaskManagement.Application.Features.User.Dtos;
using Modules.TaskManagement.Application.Responses;

namespace Modules.TaskManagement.Application.Features.User
{
    public class UserService(IUserRepository userRepository, IMapper mapper) : IUserService
    {
        public async Task<BaseResponse> Create(CreateUserRequest createUserRequest)
        {
            var user = mapper.Map<Domain.Entities.User>(createUserRequest);
            PasswordMaker.CreatePasswordHash(createUserRequest.Password, out byte[] passwordHash, out byte[] passwordSalt);
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;
            var res = await userRepository.AddAsync(user);
            return new BaseResponse
            {
                Success = res,
                Message = res ? "Created Successfully" : "Failed To Create",
            };
        }
        public async Task<BaseResponse> Update(UpdateUserRequest updateUserRequest)
        {
            var user = mapper.Map<Domain.Entities.User>(updateUserRequest);
            PasswordMaker.CreatePasswordHash(updateUserRequest.Password, out byte[] passwordHash, out byte[] passwordSalt);
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;
            var res = await userRepository.UpdateAsync(user);
            return new BaseResponse
            {
                Success = res,
                Message = res ? "Updated Successfully" : "Failed To Update",
            };
        }
    }
}
