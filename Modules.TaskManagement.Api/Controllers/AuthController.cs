using Microsoft.AspNetCore.Mvc;
using Modules.TaskManagement.Application.Features.Authentication;
using Modules.TaskManagement.Application.Features.Authentication.Dtos;
using Modules.TaskManagement.Application.Responses;

namespace Modules.TaskManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController(IAuthenticationService authService) : ControllerBase
    {
        [HttpPost("login")]
        public async Task<ActionResult<BaseResponse<LoginResponse>>> Login(LoginRequest request)
        {
            return Ok(await authService.LoginAsync(request));
        }
    }
}
