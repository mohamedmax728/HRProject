using Modules.TaskManagement.Domain.Common;
using Modules.TaskManagement.Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace Modules.TaskManagement.Domain.Entities
{
    [Table("Tasks", Schema = "TaskManagement")]
    public class Task : AuditEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int ProjectId { get; set; }
        public Project Project { get; set; }
        public int AssignedUserId { get; set; }
        public User AssignedUser { get; set; }
        public TaskStatusEnum Status { get; set; } = TaskStatusEnum.New;
        public TaskPriorityEnum Priority { get; set; }
        public DateTime DueDate { get; set; }
        public bool IsDeleted { get; set; } = false;
        public int CompanyId { get; set; }
        public Company Company { get; set; }
    }
}
