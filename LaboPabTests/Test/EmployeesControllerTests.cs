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
    public class EmployeesControllerTests
    {
        private readonly Mock<IEmployeeRepository> _mockService;
        private readonly EmployeesController _controller;

        public EmployeesControllerTests()
        {
            _mockService = new Mock<IEmployeeRepository>();
            _controller = new EmployeesController(_mockService.Object);
        }

        [Fact]
        public async Task GetEmployees_ReturnsOkResult_WithListOfEmployees()
        {
            var employees = new List<Employee>
            {
                new Employee { Id = 1, FullName = "John Doe" },
                new Employee { Id = 2, FullName = "Jane Smith" }
            };
            _mockService.Setup(s => s.GetEmployeesAsync()).ReturnsAsync(employees);

            var result = await _controller.GetEmployees();

            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnEmployees = Assert.IsType<List<Employee>>(okResult.Value);
            Assert.Equal(2, returnEmployees.Count);
        }

        [Fact]
        public async Task GetEmployee_ReturnsOkResult_WithEmployee()
        {
            var employee = new Employee { Id = 1, FullName = "John Doe" };
            _mockService.Setup(s => s.GetEmployeeByIdAsync(1)).ReturnsAsync(employee);

            var result = await _controller.GetEmployee(1);

            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnEmployee = Assert.IsType<Employee>(okResult.Value);
            Assert.Equal(1, returnEmployee.Id);
        }

        [Fact]
        public async Task GetEmployee_ReturnsNotFound_WhenEmployeeNotExists()
        {
            _mockService.Setup(s => s.GetEmployeeByIdAsync(1)).ReturnsAsync((Employee)null);

            var result = await _controller.GetEmployee(1);

            Assert.IsType<NotFoundResult>(result.Result);
        }

        [Fact]
        public async Task CreateEmployee_ReturnsCreatedAtActionResult()
        {
            var employee = new Employee { Id = 1, FullName = "John Doe" };

            var result = await _controller.CreateEmployee(employee);

            var createdAtActionResult = Assert.IsType<CreatedAtActionResult>(result);
            var returnEmployee = Assert.IsType<Employee>(createdAtActionResult.Value);
            Assert.Equal(1, returnEmployee.Id);
        }

        [Fact]
        public async Task UpdateEmployee_ReturnsNoContentResult()
        {
            var employee = new Employee { Id = 1, FullName = "John Doe" };
            _mockService.Setup(s => s.UpdateEmployeeAsync(employee)).Returns(Task.CompletedTask);

            var result = await _controller.UpdateEmployee(1, employee);

            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public async Task UpdateEmployee_ReturnsBadRequest_WhenIdMismatch()
        {
            var employee = new Employee { Id = 1, FullName = "John Doe" };

            var result = await _controller.UpdateEmployee(2, employee);

            Assert.IsType<BadRequestResult>(result);
        }

        [Fact]
        public async Task DeleteEmployee_ReturnsNoContentResult()
        {
            _mockService.Setup(s => s.DeleteEmployeeAsync(1)).Returns(Task.CompletedTask);

            var result = await _controller.DeleteEmployee(1);

            Assert.IsType<NoContentResult>(result);
        }
    }
}