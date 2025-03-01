using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskManager.Domain.Models;

namespace TaskManager.Infrastructure.Data.Configurations
{
    public class TaskConfiguration : IEntityTypeConfiguration<TaskModel>
    {
        public void Configure(EntityTypeBuilder<TaskModel> builder)
        {
            builder.ToTable("Tasks");

            builder.HasKey(t => t.Id);

            builder.Property(t => t.Title)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(t => t.IsCompleted)
                    .HasDefaultValue(false); 

            builder.HasData(
                new TaskModel { Id = new Guid("c9f5b9a1-3e8a-4f5a-9b1a-1a2b3c4d5e6f"), Title = "Hacer prueba técnica" },
                new TaskModel { Id = new Guid("a1b2c3d4-e5f6-4a5b-9c8d-1e2f3a4b5c6d"), Title = "Estudiar patrones de diseño" },
                new TaskModel { Id = new Guid("b2c3d4e5-f6a7-4b5c-9d8e-1f2a3b4c5d6e"), Title = "Leer Clean Code" },
                new TaskModel { Id = new Guid("d3e4f5a6-b7c8-4d5e-9f1a-2b3c4d5e6f7a"), Title = "Revisar SOLID" },
                new TaskModel { Id = new Guid("e4f5a6b7-c8d9-4e5f-9a1b-2c3d4e5f6a7b"), Title = "Mejorar arquitectura de APIs" },
                new TaskModel { Id = new Guid("f5a6b7c8-d9e1-4f5a-9b2c-3d4e5f6a7b8c"), Title = "Aprender EF Core" },
                new TaskModel { Id = new Guid("a6b7c8d9-e1f2-4a5b-9c3d-4e5f6a7b8c9d"), Title = "Ver tutoriales de DDD" },
                new TaskModel { Id = new Guid("b7c8d9e1-f2a3-4b5c-9d4e-5f6a7b8c9d1e"), Title = "Configurar Swagger" },
                new TaskModel { Id = new Guid("c8d9e1f2-a3b4-4c5d-9e6f-7a8b9c1d2e3f"), Title = "Hacer pruebas unitarias" },
                new TaskModel { Id = new Guid("d9e1f2a3-b4c5-4d6e-9f1a-2b3c4d5e6f7a"), Title = "Optimizar consultas SQL" },

                new TaskModel { Id = new Guid("e1f2a3b4-c5d6-4e7f-9a1b-2c3d4e5f6a7b"), Title = "Comprar café", IsCompleted = true },
                new TaskModel { Id = new Guid("f2a3b4c5-d6e7-4f8a-9b1c-2d3e4f5a6b7c"), Title = "Ejercitarse", IsCompleted = true },
                new TaskModel { Id = new Guid("a3b4c5d6-e7f8-4a9b-9c1d-2e3f4a5b6c7d"), Title = "Revisar correos", IsCompleted = true },
                new TaskModel { Id = new Guid("b4c5d6e7-f8a9-4b1c-9d2e-3f4a5b6c7d8e"), Title = "Actualizar LinkedIn", IsCompleted = true },
                new TaskModel { Id = new Guid("c5d6e7f8-a9b1-4c2d-9e3f-4a5b6c7d8e9f"), Title = "Leer documentación de ASP.NET", IsCompleted = true },
                new TaskModel { Id = new Guid("d6e7f8a9-b1c2-4d3e-9f4a-5b6c7d8e9f1a"), Title = "Configurar Docker", IsCompleted = true },
                new TaskModel { Id = new Guid("e7f8a9b1-c2d3-4e4f-9a5b-6c7d8e9f1a2b"), Title = "Actualizar currículum", IsCompleted = true },
                new TaskModel { Id = new Guid("f8a9b1c2-d3e4-4f5a-9b6c-7d8e9f1a2b3c"), Title = "Ver tutoriales de Kubernetes", IsCompleted = true },
                new TaskModel { Id = new Guid("a9b1c2d3-e4f5-4a6b-9c7d-8e9f1a2b3c4d"), Title = "Implementar autenticación JWT", IsCompleted = true },
                new TaskModel { Id = new Guid("b1c2d3e4-f5a6-4b7c-9d8e-9f1a2b3c4d5e"), Title = "Refactorizar código", IsCompleted = true }
            );

        }
    }
}
