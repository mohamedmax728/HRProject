namespace Modules.TaskManagement.Application.Features.Project.Dtos
{
    public class ProjectListResponse
    {
        public int ProjectId { get; set; }
        public string Name { get; set; }
        public int ManagerId { get; set; }
        public string ManagerFullName { get; set; }
    }
}
