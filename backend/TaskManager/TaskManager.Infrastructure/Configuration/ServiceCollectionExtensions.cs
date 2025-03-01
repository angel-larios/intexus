using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TaskManager.Infrastructure.Data;
using TaskManager.Application.UseCases;
using TaskManager.Application.Interfaces.Services;
using TaskManager.Application.Services;
using FluentValidation;
using System.Reflection;
using TaskManager.Infrastructure.Data.Repositories;
using TaskManager.Application.Interfaces.Repositories;

namespace TaskManager.Infrastructure.Configuration
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            // Registro de DbContext
            services.AddDbContext<ApplicationDbContext>(options =>
               options.UseSqlite(configuration.GetConnectionString("Database")));

            // Registro de repositorios
            services.AddScoped<ITaskRepository, TaskRepository>();

            // Registro de servicios
            services.AddScoped<ITaskQueryService, TaskQueryService>();
            services.AddScoped<ITaskCommandService, TaskCommandService>();

            //Casos De uso
            services.AddScoped<CreateTaskUseCase>();
            services.AddScoped<GetTasksUseCase>();
            services.AddScoped<GetTaskByIdUseCase>();
            services.AddScoped<UpdateTaskStatusUseCase>();
            services.AddScoped<DeleteTaskUseCase>();

            //Validator
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            return services;
        }
    }
}
