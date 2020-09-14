using EmployeeRegister.DAL.Models;
using EmployeeRegister.DAL.Repositories;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeRegister.Services
{
    public class EmployeeService
    {
        private readonly GenderRepository genderRepository;
        private readonly SkillRepository skillRepository;
        private readonly EmployeeRepository employeeRepository;

        public EmployeeService(GenderRepository genderRepository, SkillRepository skillRepository, EmployeeRepository employeeRepository)
        {
            this.genderRepository = genderRepository;
            this.skillRepository = skillRepository;
            this.employeeRepository = employeeRepository;
        }

        public async Task<ICollection<Employee>> GetEmployees()
        {
            var employees = await employeeRepository.GetAll();            

            foreach (var e in employees)
            {
                e.Skills = e.EmployeeSkills.Select(s => s.Skill).ToList();
            }
            return employees;            
        }

        public async Task<Employee> GetById(int id)
        {
            Employee employee = await employeeRepository.GetById(id);
            if (employee != null)
                employee.Skills = employee.EmployeeSkills.Select(s => s.Skill).ToList();
            return employee;
        }

        public async Task<ICollection<Skill>> GetSkillList()
        {
            return await skillRepository.GetAll();
        }

        public async Task<ICollection<Gender>> GetGenders()
        {
            return await genderRepository.GetAll();
        }

        public async Task<Employee> CreateEmployee(Employee employee)
        {            
            var validSkills = await ValidateSkills(employee.Skills);
            var gender = await ValidateGender(employee.Gender.Id);

            if (gender != null && validSkills != null)
            {
                employee.EmployeeSkills = validSkills
                .Select(s => new EmployeeSkill { Employee = employee, Skill = s }).ToList();

                employee.Gender = gender;

                return await employeeRepository.Insert(employee);
            }
            else
            {
                return null;
            }
            
        }

        private async Task<Gender> ValidateGender(int genderId)
        {
            return await genderRepository.GetById(genderId);
        }
        
        private async Task<ICollection<Skill>> ValidateSkills(ICollection<Skill> skills)
        {
            return await skillRepository.GetByIds(skills.Select(s => s.Id).ToArray());
            
        }
    }
}
