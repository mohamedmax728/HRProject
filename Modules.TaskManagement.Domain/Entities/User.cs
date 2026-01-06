using Modules.TaskManagement.Domain.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace Modules.TaskManagement.Domain.Entities
{
    [Table("Users", Schema = "TaskManagement")]
    public class User : AuditEntity
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public int CompanyId { get; set; }
        public Company Company { get; set; }
        public int RoleId { get; set; }
        public Role Role { get; set; }
        public ICollection<ProjectUsers> ProjectUsers { get; set; } = new List<ProjectUsers>();

    }
}
