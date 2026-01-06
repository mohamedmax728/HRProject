using Modules.TaskManagement.Domain.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace Modules.TaskManagement.Domain.Entities
{
    [Table("Companies", Schema = "TaskManagement")]
    public class Company : AuditEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
