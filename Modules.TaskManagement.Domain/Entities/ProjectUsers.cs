using System.ComponentModel.DataAnnotations.Schema;

namespace Modules.TaskManagement.Domain.Entities
{
    [Table("ProjectUsers", Schema = "TaskManagement")]
    public class ProjectUsers
    {
        public int Id { get; set; }

        public int CompanyId { get; set; }
        public Company Company { get; set; }

        public int ProjectId { get; set; }
        public Project Project { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public DateTime AssignedAt { get; set; }
    }
}
