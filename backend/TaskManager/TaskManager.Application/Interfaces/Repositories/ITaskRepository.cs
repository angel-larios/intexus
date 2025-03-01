using TaskManager.Domain.Models;

namespace TaskManager.Application.Interfaces.Repositories
{
    public interface ITaskRepository
    {
        Task<List<TaskModel>> GetAllAsync();
        Task<TaskModel?> GetByIdAsync(Guid id);
        Task AddAsync(TaskModel task);
        Task UpdateAsync(TaskModel task);
        Task DeleteAsync(Guid id);
    }
}
