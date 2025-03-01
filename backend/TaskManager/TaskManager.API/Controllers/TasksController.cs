using Microsoft.AspNetCore.Mvc;
using TaskManager.Application.DTOs;
using TaskManager.Application.Interfaces.Services;

namespace TaskManager.API.Controllers
{
    [ApiController]
    [Route("api/tasks")]
    public class TasksController : ControllerBase
    {
        private readonly ITaskCommandService _taskCommandService;
        private readonly ITaskQueryService _taskQueryService;

        public TasksController(ITaskCommandService taskCommandService, ITaskQueryService taskQueryService)
        {
            _taskCommandService = taskCommandService;
            _taskQueryService = taskQueryService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] TaskFilterDTO? filter = null) =>
            Ok(await _taskQueryService.GetAllTasksAsync(filter ?? new TaskFilterDTO()));

        [HttpGet("getById/{id}")]
        public async Task<IActionResult> GetById(Guid id) => 
            Ok(await _taskQueryService.GetTaskByIdAsync(id));

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateTaskDTO createTaskDto) => 
            Ok(await _taskCommandService.CreateTaskAsync(createTaskDto));

        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateStatus(Guid id, [FromBody] UpdateTaskStatusDTO updateTaskStatusDto) =>
            Ok(await _taskCommandService.UpdateTaskStatusAsync(id, updateTaskStatusDto));

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id) => 
            Ok(await _taskCommandService.DeleteTaskAsync(id));
    }
}
