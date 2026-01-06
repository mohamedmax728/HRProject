using Modules.TaskManagement.Domain.Common;
using Modules.TaskManagement.Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace Modules.TaskManagement.Domain.Entities
{
    [Table("Roles", Schema = "TaskManagement")]
    public class Role : AuditEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public RoleCodeEnum RoleCode { get; set; }
        public ICollection<User> Users { get; set; } = new List<User>();
    }
}
