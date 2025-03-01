using TaskManager.Application.DTOs;
using TaskManager.Application.Interfaces.Services;
using TaskManager.Application.UseCases;

namespace TaskManager.Application.Services
{
    public class TaskQueryService : ITaskQueryService
    {
        private readonly GetTasksUseCase _getTasksUseCase;
        private readonly GetTaskByIdUseCase _getTaskByIdUseCase;

        public TaskQueryService(GetTasksUseCase getTasksUseCase, GetTaskByIdUseCase getTaskByIdUseCase)
        {
            _getTasksUseCase = getTasksUseCase;
            _getTaskByIdUseCase = getTaskByIdUseCase;
        }

        public async Task<List<TaskDTO>> GetAllTasksAsync(TaskFilterDTO filter)
        {
            var tasks = await _getTasksUseCase.ExecuteAsync(filter);
            return tasks.Select(task => new TaskDTO
            {
                Id = task.Id,
                Title = task.Title,
                IsCompleted = task.IsCompleted
            }).ToList();
        }

        public async Task<TaskDTO?> GetTaskByIdAsync(Guid id)
        {
            var task = await _getTaskByIdUseCase.ExecuteAsync(id);
            return task == null ? null : new TaskDTO { Id = task.Id, Title = task.Title, IsCompleted = task.IsCompleted };
        }
    }
}
