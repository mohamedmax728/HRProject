using Microsoft.AspNetCore.Http;
using Modules.TaskManagement.Application.Common.Abstractions;

namespace Modules.TaskManagement.Persistence.Identity
{
    public class TenantProvider : ITenantProvider
    {
        public int CompanyId { get; }

        public TenantProvider(IHttpContextAccessor accessor)
        {
            var claim = accessor.HttpContext?
                .User
                .FindFirst("companyId");

            CompanyId = int.Parse(claim!.Value);
        }
    }
}
