using AutoMapper;
using Modules.TaskManagement.Application.Common.Models;
using Modules.TaskManagement.Application.Contracts.Persistence;
using Modules.TaskManagement.Application.Features.Project.Dtos;
using Modules.TaskManagement.Application.Responses;

namespace Modules.TaskManagement.Application.Features.Project
{
    public class ProjectService(IProjectRepository projectRepository,
        IUserRepository userRepository, IProjectUsersRepository projectUsersRepository, IMapper mapper) : IProjectService
    {
        public async Task<BaseResponse> Create(CreateProjectRequest createProjectRequest)
        {
            try
            {
                if (await IsAssignUserManager(createProjectRequest.ManagerId))
                {
                    return new BaseResponse
                    {
                        Success = false,
                        Message = "This user is not manager",
                    };
                }
                var project = mapper.Map<Domain.Entities.Project>(createProjectRequest);
                project.ProjectUsers.Add(new Domain.Entities.ProjectUsers
                {
                    UserId = createProjectRequest.ManagerId,
                });
                var res = await projectRepository.AddAsync(project);
                return new BaseResponse
                {
                    Success = res,
                    Message = res ? "Created Successfully" : "Failed To Create",
                };
            }
            catch (Exception ex)
            {
                // Log the exception (ex) as needed
                return new BaseResponse
                {
                    Success = false,
                    Message = "Failed To Create"
                };
            }
        }
        public async Task<BaseResponse> Update(UpdateProjectRequest updateProjectRequest)
        {
            if (await IsAssignUserManager(updateProjectRequest.ManagerId))
            {
                return new BaseResponse
                {
                    Success = false,
                    Message = "This user is not manager",
                };
            }

            var project = await projectRepository.GetAsync(s => s.Id == updateProjectRequest.ProjectId, s => s.ProjectUsers);
            project.ProjectUsers.FirstOrDefault(s => s.UserId == project.ManagerId)!.UserId = updateProjectRequest.ManagerId;
            var res = await projectRepository.UpdateAsync(mapper.Map(updateProjectRequest, project));
            return new BaseResponse
            {
                Success = res,
                Message = res ? "Updated Successfully" : "Failed To Update",
            };
        }
        public async Task<BaseResponse<PaginatedResult<ProjectListResponse>>> ProjectListDto(int pageSize, int pageNumber)
        {
            var projects = await projectRepository.ListPagedAsync<ProjectListResponse>(pageNumber, pageSize, null, s => s.Manager);
            return new BaseResponse<PaginatedResult<ProjectListResponse>>
            {
                Data = mapper.Map<PaginatedResult<ProjectListResponse>>(projects),
                Success = true,
                Message = "Fetched Successfully",
            };
        }
        #region Private Methods
        private async Task<bool> IsAssignUserManager(int userId)
        {
            return (await userRepository.GetAsync(s => s.Id == userId && s.Role.RoleCode == Domain.Enums.RoleCodeEnum.Manager,
                s => s.Role)) is not null;
        }
        #endregion
    }
}
