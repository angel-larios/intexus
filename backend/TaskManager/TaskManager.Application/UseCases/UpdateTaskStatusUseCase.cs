using TaskManager.Application.Interfaces.Repositories;
using TaskManager.Domain.Models;

namespace TaskManager.Application.UseCases
{
    public class UpdateTaskStatusUseCase
    {
        private readonly ITaskRepository _taskRepository;

        public UpdateTaskStatusUseCase(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public async Task<ResponsesModel<bool>> ExecuteAsync(Guid id, bool isCompleted)
        {
            try
            {
                if (id == Guid.Empty)
                    return new ResponsesModel<bool>(false, "El ID de la tarea no es válido.");

                var task = await _taskRepository.GetByIdAsync(id);
                if (task == null)
                    return new ResponsesModel<bool>(false, $"No se encontró una tarea con el ID {id}.");

                if (isCompleted)
                {
                    task.Complete();
                }
                else
                {
                    task.MarkAsPending();
                }
                await _taskRepository.UpdateAsync(task);

                return new ResponsesModel<bool>(true, "La tarea se actualizó correctamente.");
            }
            catch (Exception ex)
            {
                return new ResponsesModel<bool>(false, "Ocurrió un error al procesar la tarea.", new List<string> { ex.Message });
            }
        }
    }
}
