using LaboPabApi.Controllers;
using LaboPabApi.Entities;
using LaboPabApi.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaboPabTests.Test
{
    public class DepartmentsControllerTests
    {
        private readonly Mock<IDepartmentService> _mockService;
        private readonly DepartmentsController _controller;

        public DepartmentsControllerTests()
        {
            _mockService = new Mock<IDepartmentService>();
            _controller = new DepartmentsController(_mockService.Object);
        }

        [Fact]
        public async Task GetDepartments_ReturnsOkResult_WithListOfDepartments()
        {
            var departments = new List<Department>
            {
                new Department { Id = 1, Name = "HR" },
                new Department { Id = 2, Name = "Finance" }
            };
            _mockService.Setup(s => s.GetDepartmentsAsync()).ReturnsAsync(departments);

            var result = await _controller.GetDepartments();

            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnDepartments = Assert.IsType<List<Department>>(okResult.Value);
            Assert.Equal(2, returnDepartments.Count);
        }

        [Fact]
        public async Task GetDepartment_ReturnsOkResult_WithDepartment()
        {
            var department = new Department { Id = 1, Name = "HR" };
            _mockService.Setup(s => s.GetDepartmentByIdAsync(1)).ReturnsAsync(department);

            var result = await _controller.GetDepartment(1);

            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnDepartment = Assert.IsType<Department>(okResult.Value);
            Assert.Equal(1, returnDepartment.Id);
        }

        [Fact]
        public async Task GetDepartment_ReturnsNotFound_WhenDepartmentNotExists()
        {
            _mockService.Setup(s => s.GetDepartmentByIdAsync(1)).ReturnsAsync((Department)null);

            var result = await _controller.GetDepartment(1);

            Assert.IsType<NotFoundResult>(result.Result);
        }

        [Fact]
        public async Task CreateDepartment_ReturnsCreatedAtActionResult()
        {
            var department = new Department { Id = 1, Name = "HR" };

            var result = await _controller.CreateDepartment(department);

            var createdAtActionResult = Assert.IsType<CreatedAtActionResult>(result);
            var returnDepartment = Assert.IsType<Department>(createdAtActionResult.Value);
            Assert.Equal(1, returnDepartment.Id);
        }

        [Fact]
        public async Task UpdateDepartment_ReturnsNoContentResult()
        {
            var department = new Department { Id = 1, Name = "HR" };
            _mockService.Setup(s => s.UpdateDepartmentAsync(department)).Returns(Task.CompletedTask);

            var result = await _controller.UpdateDepartment(1, department);

            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public async Task UpdateDepartment_ReturnsBadRequest_WhenIdMismatch()
        {
            var department = new Department { Id = 1, Name = "HR" };

            var result = await _controller.UpdateDepartment(2, department);

            Assert.IsType<BadRequestResult>(result);
        }

        [Fact]
        public async Task DeleteDepartment_ReturnsNoContentResult()
        {
            _mockService.Setup(s => s.DeleteDepartmentAsync(1)).Returns(Task.CompletedTask);

            var result = await _controller.DeleteDepartment(1);

            Assert.IsType<NoContentResult>(result);
        }
    }
}