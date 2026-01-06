namespace Modules.TaskManagement.Application.Common.Abstractions
{
    public interface ITenantProvider
    {
        int CompanyId { get; }
    }
}
