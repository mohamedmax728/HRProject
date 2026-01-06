using Microsoft.AspNetCore.Mvc;
using Modules.TaskManagement.Application.Features.Task;
using Modules.TaskManagement.Application.Features.Task.Dtos;
using Modules.TaskManagement.Application.Responses;

namespace Modules.TaskManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController(ITaskService taskService) : ControllerBase
    {
        [HttpPost]
        public async Task<ActionResult<BaseResponse>> Create([FromBody] CreateTaskRequest createTaskRequest)
        {
            return Ok(await taskService.Create(createTaskRequest));
        }
        [HttpPut]
        public async Task<ActionResult<BaseResponse>> Update([FromBody] UpdateTaskRequest updateTaskRequest)
        {
            return Ok(await taskService.Update(updateTaskRequest));
        }
    }
}
