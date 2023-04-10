using Backend_Login_Register_Task.Models;
using Backend_Login_Register_Task.Repository.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend_Login_Register_Task.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
  
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository _employeeRepository;
        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var employees = _employeeRepository.GetAllEmployees();
            return Ok(employees);
        }
        [HttpGet("int:id")]
        public IActionResult Details(int id)
        {
            var employee = _employeeRepository.GetEmployeeById(id);
            return Ok(employee);
        }



        [HttpPost]
        public IActionResult Create(Employee employee)
        {
            _employeeRepository.AddEmployee(employee);

            return Ok(employee);
        }

        [HttpPut]
        public IActionResult Edit(Employee employee)
        {
            _employeeRepository.UpdateEmployee(employee);
            return Ok(employee);
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            _employeeRepository.DeleteEmployee(id);
            return Ok();
        }
    }
}
    
