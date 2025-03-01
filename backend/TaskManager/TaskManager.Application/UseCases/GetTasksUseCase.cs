using TaskManager.Application.DTOs;
using TaskManager.Application.Interfaces.Repositories;
using TaskManager.Domain.Models;

namespace TaskManager.Application.UseCases
{
    public class GetTasksUseCase
    {
        private readonly ITaskRepository _taskRepository;

        public GetTasksUseCase(ITaskRepository taskRepository) => _taskRepository = taskRepository;

        public async Task<List<TaskModel>> ExecuteAsync(TaskFilterDTO filter)
        {
            var tasks = await _taskRepository.GetAllAsync();

            if (!string.IsNullOrEmpty(filter.Title))
                tasks = tasks.Where(t => t.Title.Contains(filter.Title, StringComparison.OrdinalIgnoreCase)).ToList();

            if (filter.IsCompleted.HasValue)
                tasks = tasks.Where(t => t.IsCompleted == filter.IsCompleted.Value).ToList();

            return tasks;
        }

    }
}
