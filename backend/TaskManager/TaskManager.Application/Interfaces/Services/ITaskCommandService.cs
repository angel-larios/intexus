using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Application.DTOs;
using TaskManager.Domain.Models;

namespace TaskManager.Application.Interfaces.Services
{
    public interface ITaskCommandService
    {
        Task<TaskDTO> CreateTaskAsync(CreateTaskDTO createTaskDto);
        Task<ResponsesModel<bool>> UpdateTaskStatusAsync(Guid id, UpdateTaskStatusDTO updateTaskStatusDto);
        Task<ResponsesModel<bool>> DeleteTaskAsync(Guid id);
    }
}
