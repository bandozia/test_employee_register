using EmployeeRegister.DAL.Models;
using EmployeeRegister.DAL.Repositories;
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
        private readonly SkillRepository skillRepository;
        private readonly GenderRepository genderRepository;
        private readonly EmployeeRepository employeeRepository;

        public EmployeeController(SkillRepository skillRepository, GenderRepository sexRepository, 
            EmployeeRepository employeeRepository)
        {
            this.skillRepository = skillRepository;
            this.genderRepository = sexRepository;
            this.employeeRepository = employeeRepository;
        }

        [HttpPost]
        public async Task<IActionResult> InsertEmployee([FromBody] Employee employee)
        {
            Employee newEmployee = await employeeRepository.Insert(employee);
            return Created($"/api/employee/{newEmployee.Id}", newEmployee);
        }

        [HttpGet("skill-list")]
        public async Task<ICollection<Skill>> GetSkillList()
        {
            return await skillRepository.GetAll();
        }

        [HttpGet("gender-list")]
        public async Task<ICollection<Gender>> GetGenderList()
        {
            return await genderRepository.GetAll();
        }                

    }
}
