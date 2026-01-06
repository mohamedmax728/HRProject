using Modules.TaskManagement.Api;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi

var app = builder.ConfigureServices().ConfigurePiplines();

app.Run();
