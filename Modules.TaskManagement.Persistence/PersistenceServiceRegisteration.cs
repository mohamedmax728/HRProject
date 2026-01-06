using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Modules.TaskManagement.Application.Common.Abstractions;
using Modules.TaskManagement.Application.Contracts.Persistence;
using Modules.TaskManagement.Persistence.Repositories;
using Modules.TaskManagement.Persistence.Security;

namespace Modules.TaskManagement.Persistence
{
    public static class PersistenceServiceRegisteration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<TaskManagementDbContext>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString("TaskManagementConnectionString"),
                    b => b.MigrationsAssembly(typeof(TaskManagementDbContext).Assembly.FullName)));
            services.AddScoped(typeof(Application.Contracts.Persistence.IAsyncRepository<>), typeof(Repositories.BaseRepository<>));
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IProjectUsersRepository, ProjectUsersRepository>();
            services.AddScoped<ITaskRepository, TaskRepository>();
            services.AddScoped<IProjectRepository, ProjectRepository>();
            services.AddScoped<IJwtTokenGenerator, JwtTokenGenerator>();

            return services;
        }
    }
}
