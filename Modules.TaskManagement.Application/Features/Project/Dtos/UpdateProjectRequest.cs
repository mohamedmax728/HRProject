namespace Modules.TaskManagement.Application.Features.Project.Dtos
{
    public class UpdateProjectRequest
    {
        public int ProjectId { get; set; }
        public string Name { get; set; }
        public int ManagerId { get; set; }
    }
}
