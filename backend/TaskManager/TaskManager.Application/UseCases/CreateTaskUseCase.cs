using TaskManager.Application.Interfaces.Repositories;
using TaskManager.Domain.Models;

namespace TaskManager.Application.UseCases
{
    public class CreateTaskUseCase
    {
        private readonly ITaskRepository _taskRepository;

        public CreateTaskUseCase(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public async Task<TaskModel> ExecuteAsync(string title)
        {
            var task = new TaskModel(title);
            await _taskRepository.AddAsync(task);
            return task;
        }
    }
}
