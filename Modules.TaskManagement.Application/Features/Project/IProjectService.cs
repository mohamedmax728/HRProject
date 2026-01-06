using Modules.TaskManagement.Application.Common.Models;
using Modules.TaskManagement.Application.Features.Project.Dtos;
using Modules.TaskManagement.Application.Responses;

namespace Modules.TaskManagement.Application.Features.Project
{
    public interface IProjectService
    {
        Task<BaseResponse> Create(CreateProjectRequest createProjectRequest);
        Task<BaseResponse> Update(UpdateProjectRequest updateProjectRequest);
        Task<BaseResponse<PaginatedResult<ProjectListResponse>>> ProjectListDto(int pageSize, int pageNumber);
    }
}
