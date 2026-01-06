namespace Modules.TaskManagement.Application.Features.User.Dtos
{
    public class UpdateUserRequest
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string? Password { get; set; }
        public int CompanyId { get; set; }
        public int RoleId { get; set; }
    }
}
