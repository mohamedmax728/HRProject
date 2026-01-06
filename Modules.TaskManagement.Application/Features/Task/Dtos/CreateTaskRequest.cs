using Modules.TaskManagement.Domain.Enums;

namespace Modules.TaskManagement.Application.Features.Task.Dtos
{
    public class CreateTaskRequest
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int ProjectId { get; set; }
        public int AssignedUserId { get; set; }
        public TaskPriorityEnum Priority { get; set; }
        public DateTime DueDate { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}
