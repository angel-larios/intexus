using TaskManager.Application.Interfaces.Repositories;
using TaskManager.Domain.Models;

namespace TaskManager.Application.UseCases
{
    public class DeleteTaskUseCase
    {
        private readonly ITaskRepository _taskRepository;

        public DeleteTaskUseCase(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public async Task<ResponsesModel<bool>> ExecuteAsync(Guid id)
        {
            try
            {
                if (id == Guid.Empty) 
                    return new ResponsesModel<bool>(false, "El ID de la tarea no es válido.");
                var task = await _taskRepository.GetByIdAsync(id);
                if (task == null) 
                    return new ResponsesModel<bool>(false, $"No se encontró una tarea con el ID {id}.");
                await _taskRepository.DeleteAsync(id);
                return new ResponsesModel<bool>(true, "La tarea se eliminó correctamente.");
            }
            catch (Exception ex)
            {
                return new ResponsesModel<bool>(false, "Ocurrió un error al eliminar la tarea.", new List<string> { ex.Message });
            }
        }
    }
}
