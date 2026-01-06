using Microsoft.AspNetCore.Mvc;
using Modules.TaskManagement.Application.Common.Models;
using Modules.TaskManagement.Application.Features.Project;
using Modules.TaskManagement.Application.Features.Project.Dtos;
using Modules.TaskManagement.Application.Responses;

namespace Modules.TaskManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController(IProjectService projectService) : ControllerBase
    {
        [HttpPost]
        public async Task<ActionResult<BaseResponse>> Create([FromBody] CreateProjectRequest createProjectRequest)
        {
            return Ok(await projectService.Create(createProjectRequest));
        }
        [HttpPut]
        public async Task<ActionResult<BaseResponse>> Update([FromBody] UpdateProjectRequest updateProjectRequest)
        {
            return Ok(await projectService.Update(updateProjectRequest));
        }
        [HttpGet]
        public async Task<ActionResult<BaseResponse<PaginatedResult<ProjectListResponse>>>> ProjectListDto([FromQuery] int pageSize, [FromQuery] int pageNumber)
        {
            return Ok(await projectService.ProjectListDto(pageSize, pageNumber));
        }
    }
}
