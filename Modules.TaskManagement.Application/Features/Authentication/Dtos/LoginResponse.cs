namespace Modules.TaskManagement.Application.Features.Authentication.Dtos
{
    public class LoginResponse
    {
        public string Token { get; set; }
        public DateTime ExpiresAt { get; set; }
    }

}
