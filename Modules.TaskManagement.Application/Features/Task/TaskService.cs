using AutoMapper;
using Modules.TaskManagement.Application.Contracts.Persistence;
using Modules.TaskManagement.Application.Features.Task.Dtos;
using Modules.TaskManagement.Application.Responses;

namespace Modules.TaskManagement.Application.Features.Task
{
    public class TaskService(ITaskRepository taskRepository, IProjectRepository projectRepository,
        IUserRepository userRepository,
        IMapper mapper) : ITaskService
    {
        public async Task<BaseResponse> Create(CreateTaskRequest createTaskRequest)
        {
            if (await IsAssignUserEmployee(createTaskRequest.AssignedUserId))
            {
                return new BaseResponse
                {
                    Success = false,
                    Message = "This user is not employee",
                };
            }
            var task = mapper.Map<Domain.Entities.Task>(createTaskRequest);
            task.Project.ProjectUsers.Add(new Domain.Entities.ProjectUsers
            {
                UserId = createTaskRequest.AssignedUserId,
                AssignedAt = DateTime.UtcNow,
            });
            var res = await taskRepository.AddAsync(task);
            return new BaseResponse
            {
                Success = res,
                Message = res ? "Created Successfully" : "Failed To Create",
            };
        }
        public async Task<BaseResponse> Update(UpdateTaskRequest updateTaskRequest)
        {
            if (await IsAssignUserEmployee(updateTaskRequest.AssignedUserId))
            {
                return new BaseResponse
                {
                    Success = false,
                    Message = "This user is not employee",
                };
            }

            var task = await taskRepository.GetAsync(s => s.Id == updateTaskRequest.Id, s => s.Project.ProjectUsers);
            if (task.ProjectId == updateTaskRequest.ProjectId)
            {
                task.Project.ProjectUsers.FirstOrDefault(s => s.UserId == task.AssignedUserId)!.UserId = updateTaskRequest.AssignedUserId;
            }
            else
            {
                var projectUser = task.Project.ProjectUsers.FirstOrDefault(s => s.UserId == task.AssignedUserId);
                task.Project.ProjectUsers.Remove(projectUser!);
                var newProject = await projectRepository.GetAsync(s => s.Id == updateTaskRequest.ProjectId, s => s.ProjectUsers);
                newProject.ProjectUsers.Add(new Domain.Entities.ProjectUsers
                {
                    UserId = updateTaskRequest.AssignedUserId,
                    AssignedAt = DateTime.UtcNow,
                });
                task.Project = newProject;
            }
            var res = await taskRepository.UpdateAsync(mapper.Map(updateTaskRequest, task));
            return new BaseResponse
            {
                Success = res,
                Message = res ? "Created Successfully" : "Failed To Create",
            };
        }

        #region Private Methods
        private async Task<bool> IsAssignUserEmployee(int userId)
        {
            return (await userRepository.GetAsync(s => s.Id == userId && s.Role.RoleCode == Domain.Enums.RoleCodeEnum.Employee,
                s => s.Role)) is not null;
        }
        #endregion
    }
}
