using Moq;
using TaskManager.API.Controllers;
using TaskManager.Application.DTOs;
using TaskManager.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

using TaskManager.Domain.Models;

namespace TaskManager.Tests
{
    public class TasksControllerTests
    {
        private readonly Mock<ITaskCommandService> _mockTaskCommandService;
        private readonly Mock<ITaskQueryService> _mockTaskQueryService;
        private readonly TasksController _controller;

        public TasksControllerTests()
        {
            _mockTaskCommandService = new Mock<ITaskCommandService>();
            _mockTaskQueryService = new Mock<ITaskQueryService>();
            _controller = new TasksController(_mockTaskCommandService.Object, _mockTaskQueryService.Object);
        }

        [Fact]
        public async Task GetAll_ReturnsOkResult()
        {
            var filter = new TaskFilterDTO();
            _mockTaskQueryService.Setup(service => service.GetAllTasksAsync(It.IsAny<TaskFilterDTO>()))
                .ReturnsAsync(new List<TaskDTO>());

            var result = await _controller.GetAll(filter);

            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.NotNull(okResult);
        }

        [Fact]
        public async Task GetById_ReturnsOkResult()
        {
            var taskId = Guid.NewGuid();
            _mockTaskQueryService.Setup(service => service.GetTaskByIdAsync(taskId))
                .ReturnsAsync(new TaskDTO());

            var result = await _controller.GetById(taskId);

            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.NotNull(okResult);
        }

        [Fact]
        public async Task Create_ReturnsOkResult()
        {
            var createTaskDto = new CreateTaskDTO();
            _mockTaskCommandService.Setup(service => service.CreateTaskAsync(createTaskDto))
                .ReturnsAsync(new TaskDTO());

            var result = await _controller.Create(createTaskDto);
            var okResult = Assert.IsType<OkObjectResult>(result);

            Assert.NotNull(okResult);
        }

        [Fact]
        public async Task UpdateStatus_ReturnsOkResult()
        {
            var taskId = Guid.NewGuid();
            var updateTaskStatusDto = new UpdateTaskStatusDTO();

            var response = new ResponsesModel<bool>(true, "Prueba de edicion correcta", true);  

            _mockTaskCommandService.Setup(service => service.UpdateTaskStatusAsync(taskId, updateTaskStatusDto))
                .ReturnsAsync(response);  // Retorna un Task<ResponsesModel<bool>> simulado

            var result = await _controller.UpdateStatus(taskId, updateTaskStatusDto);

            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.NotNull(okResult);
        }




        [Fact]
        public async Task Delete_ReturnsOkResult()
        {
            var taskId = Guid.NewGuid();
            var response = new ResponsesModel<bool>(true, "Prueba de eliminacion correcta", true); 

            _mockTaskCommandService.Setup(service => service.DeleteTaskAsync(taskId))
                .ReturnsAsync(response);  

            var result = await _controller.Delete(taskId);

            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.NotNull(okResult);
        }

    }
}
