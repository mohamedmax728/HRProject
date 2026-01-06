using Modules.TaskManagement.Domain.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace Modules.TaskManagement.Domain.Entities
{
    [Table("Projects", Schema = "TaskManagement")]
    public class Project : AuditEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CompanyId { get; set; }
        public Company Company { get; set; }
        public int ManagerId { get; set; }
        public User Manager { get; set; }
        public ICollection<ProjectUsers> ProjectUsers { get; set; } = new List<ProjectUsers>();
    }
}
