using Modules.TaskManagement.Application.Features.Task.Dtos;
using Modules.TaskManagement.Application.Responses;

namespace Modules.TaskManagement.Application.Features.Task
{
    public interface ITaskService
    {
        Task<BaseResponse> Create(CreateTaskRequest createTaskRequest);
        Task<BaseResponse> Update(UpdateTaskRequest updateTaskRequest);
    }
}
