using InterviewTest.Api.Controllers;
using InterviewTest.Applciation.Interface;
using InterviewTest.Applciation.RequesDTO.Employee;
using InterviewTest.Applciation.Services;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using System.Web.Http;

namespace InterviewTest.Tests
{
    [TestFixture]
    public class UnitTest1
    {
        private EmployeeController _controller;
        private IEmployeeService _service;
        [SetUp]
        public void Setup()
        {

            _service = new EmployeeService();
            _controller = new EmployeeController(_service);
        }
        [Test]
        public void GetSingleResult()
        {
            // Arrange
            int search = 33;
            // Act
            var result = _controller.GetSingle(search);

            // Assert
            Assert.IsInstanceOf<Task<IActionResult>>(result);
        }
        [Test]
        public void GetAll()
        {
            // Arrange
            string? search = null;
            // Act
            var result = _controller.GetAllEmployees(search);

            // Assert
            Assert.IsInstanceOf<Task<IActionResult>>(result);
        }
        [Test]
        public void GetAllSearch()
        {
            // Arrange
            string search = "testttt";
            // Act
            var result = _controller.GetAllEmployees(search);

            // Assert
            Assert.IsInstanceOf<Task<IActionResult>>(result);
        }
        [Test]
        public void RegisterEmployee()
        {
            // Arrange
            CreateOrUpdateEmployeeRequest obj = new CreateOrUpdateEmployeeRequest { Id = 0, Department = "Test", Email = "USAMACH343@GMAIL.com", DateOfBirth = DateTime.UtcNow };
            // Act
            var result = _controller.CreateOrUpdateEmployee(obj);

            // Assert
            Assert.IsInstanceOf<Task<IActionResult>>(result);
        }
        [Test]
        public void DeleteEmployee()
        {
            // Arrange
            int id = 33;
            // Act
            var result = _controller.DeleteEmployee(id);

            // Assert
            Assert.IsInstanceOf<Task<IActionResult>>(result);
        }
    }


    
}