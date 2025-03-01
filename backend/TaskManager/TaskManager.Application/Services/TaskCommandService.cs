using TaskManager.Application.DTOs;
using TaskManager.Application.Interfaces.Services;
using TaskManager.Application.UseCases;
using TaskManager.Domain.Models;

namespace TaskManager.Application.Services
{
    public class TaskCommandService : ITaskCommandService
    {
        private readonly CreateTaskUseCase _createTaskUseCase;
        private readonly UpdateTaskStatusUseCase _updateTaskStatusUseCase;
        private readonly DeleteTaskUseCase _deleteTaskUseCase;

        public TaskCommandService(CreateTaskUseCase createTaskUseCase, UpdateTaskStatusUseCase updateTaskStatusUseCase, DeleteTaskUseCase deleteTaskUseCase)
        {
            _createTaskUseCase = createTaskUseCase;
            _updateTaskStatusUseCase = updateTaskStatusUseCase;
            _deleteTaskUseCase = deleteTaskUseCase;
        }

        public async Task<TaskDTO> CreateTaskAsync(CreateTaskDTO createTaskDto)
        {
            var task = await _createTaskUseCase.ExecuteAsync(createTaskDto.Title);
            return new TaskDTO { Id = task.Id, Title = task.Title, IsCompleted = task.IsCompleted };
        }

        public async Task<ResponsesModel<bool>> UpdateTaskStatusAsync(Guid id, UpdateTaskStatusDTO updateTaskStatusDto)
        {
            return await _updateTaskStatusUseCase.ExecuteAsync(id, updateTaskStatusDto.IsCompleted);
        }

        public async Task<ResponsesModel<bool>> DeleteTaskAsync(Guid id)
        {
            return await _deleteTaskUseCase.ExecuteAsync(id);
        }
    }
}
