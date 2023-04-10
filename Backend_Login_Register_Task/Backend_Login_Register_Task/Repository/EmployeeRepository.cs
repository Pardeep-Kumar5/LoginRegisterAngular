using Backend_Login_Register_Task.Data;
using Backend_Login_Register_Task.Models;
using Backend_Login_Register_Task.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend_Login_Register_Task.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly ApplicationDbContext _context;
        public EmployeeRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public void AddEmployee(Employee employee)
        {
            _context.Add(employee);
            _context.SaveChanges();
        }

        public void DeleteEmployee(int id)
        {
            var employeeRemove = _context.Employees.FirstOrDefault(e => e.Id == id);
            if (employeeRemove != null)
            {
                _context.Remove(employeeRemove);
            }
            _context.SaveChanges();
        }

        public IEnumerable<Employee> GetAllEmployees()
        {
            return _context.Employees;
        }

        public Employee GetEmployeeById(int id)
        {
            return _context.Employees.FirstOrDefault(e => e.Id == id);
        }

        public void UpdateEmployee(Employee employee)
        {
            var existingEmployee = _context.Employees.FirstOrDefault(e => e.Id == employee.Id);
            if (existingEmployee != null)
            {
                existingEmployee.Name = employee.Name;
                existingEmployee.Address = employee.Address;
                existingEmployee.PhoneNumber = employee.PhoneNumber;
            }
            _context.SaveChanges();

        }
    }
}
