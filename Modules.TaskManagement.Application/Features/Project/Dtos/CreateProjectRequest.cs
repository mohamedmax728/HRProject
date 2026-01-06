namespace Modules.TaskManagement.Application.Features.Project.Dtos
{
    public class CreateProjectRequest
    {
        public string Name { get; set; }
        public int ManagerId { get; set; }
    }
}
