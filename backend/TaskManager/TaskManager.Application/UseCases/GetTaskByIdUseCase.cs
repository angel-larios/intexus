using TaskManager.Application.Interfaces.Repositories;
using TaskManager.Domain.Models;

namespace TaskManager.Application.UseCases
{
    public class GetTaskByIdUseCase
    {
        private readonly ITaskRepository _taskRepository;

        public GetTaskByIdUseCase(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public async Task<TaskModel?> ExecuteAsync(Guid id)
        {
            return await _taskRepository.GetByIdAsync(id);
        }
    }
}
