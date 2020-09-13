using EmployeeRegister.DAL.Models;
using EmployeeRegister.DAL.Repositories;
using EmployeeRegister.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeRegister.Controllers
{
    [Route("api/employee")]
    public class EmployeeController : Controller
    {
        private readonly EmployeeService employeeService;

        public EmployeeController(EmployeeService employeeService)
        {
            this.employeeService = employeeService;
        }

        [HttpGet]
        public async Task<ICollection<Employee>> GetEmployees()
        {
            return await employeeService.GetEmployees();
        }

        [HttpPost]
        public async Task<IActionResult> InsertEmployee([FromBody] Employee employee)
        {
            if (ModelState.IsValid)
            {
                if (employee.Skills.Count < 1)
                    return BadRequest("validation");

                Employee newEmployee = await employeeService.CreateEmployee(employee);
                return Created($"/api/employee/{newEmployee.Id}", newEmployee);
            }
            else
            {
                return BadRequest("validation");
            }
        }

        [HttpGet("skill-list")]
        public async Task<ICollection<Skill>> GetSkillList()
        {
            return await employeeService.GetSkillList();
        }

        [HttpGet("gender-list")]
        public async Task<ICollection<Gender>> GetGenderList()
        {
            return await employeeService.GetGenders();
        }

    }
}
