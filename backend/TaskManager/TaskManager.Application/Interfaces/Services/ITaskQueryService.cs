using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Application.DTOs;

namespace TaskManager.Application.Interfaces.Services
{
    public interface ITaskQueryService
    {
        Task<List<TaskDTO>> GetAllTasksAsync(TaskFilterDTO filter);
        Task<TaskDTO?> GetTaskByIdAsync(Guid id);
    }
}
