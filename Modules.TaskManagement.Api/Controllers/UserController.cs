using Microsoft.AspNetCore.Mvc;
using Modules.TaskManagement.Application.Features.User;
using Modules.TaskManagement.Application.Features.User.Dtos;
using Modules.TaskManagement.Application.Responses;

namespace Modules.TaskManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController(IUserService userService) : ControllerBase
    {
        [HttpPost]
        public async Task<ActionResult<BaseResponse>> Create([FromBody] CreateUserRequest createUserRequest)
        {
            return Ok(await userService.Create(createUserRequest));
        }
        [HttpPut]
        public async Task<ActionResult<BaseResponse>> Update([FromBody] UpdateUserRequest updateUserRequest)
        {
            return Ok(await userService.Update(updateUserRequest));
        }
    }
}
