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
        private readonly SexRepository sexRepository;
        private readonly EmployeeRepository employeeRepository;

        public EmployeeController(SkillRepository skillRepository, SexRepository sexRepository, 
            EmployeeRepository employeeRepository)
        {
            this.skillRepository = skillRepository;
            this.sexRepository = sexRepository;
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

        [HttpGet("sex-list")]
        public async Task<ICollection<Sex>> GetSexList()
        {
            return await sexRepository.GetAll();
        }                

    }
}
