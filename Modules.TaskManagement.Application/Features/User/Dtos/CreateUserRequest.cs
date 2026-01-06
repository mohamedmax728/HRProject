namespace Modules.TaskManagement.Application.Features.User.Dtos
{
    public class CreateUserRequest
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int CompanyId { get; set; }
        public int RoleId { get; set; }
    }
}
