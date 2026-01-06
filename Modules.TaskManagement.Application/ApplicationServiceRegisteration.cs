using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Modules.TaskManagement.Application.Features.Authentication;
using Modules.TaskManagement.Application.Features.Authentication.Dtos;
using Modules.TaskManagement.Application.Features.Authentication.Dtos.Validators;
using Modules.TaskManagement.Application.Features.Project;
using Modules.TaskManagement.Application.Features.Task;
using Modules.TaskManagement.Application.Features.User;

namespace Modules.TaskManagement.Application
{
    public static class ApplicationServiceRegisteration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            //services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
            services.AddScoped<IProjectService, ProjectService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ITaskService, TaskService>();
            services.AddScoped<IAuthenticationService, AuthenticationService>();
            services.AddScoped<IValidator<LoginRequest>, LoginRequestValidator>();

            return services;
        }
    }
}