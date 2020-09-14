using EmployeeRegister.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System.Collections.Generic;

namespace EmployeeRegister.DAL
{
    public class CoreContext : DbContext
    {
        public CoreContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Gender>(sex =>
            {
                sex.HasKey(s => s.Id);
                
                sex.HasData(new Gender(GenderSign.F, "Feminino") { Id = 1 });
                sex.HasData(new Gender(GenderSign.M, "Masculino") { Id = 2 });
                sex.HasData(new Gender(GenderSign.ND, "Prefio não responder") { Id = 3 });
            });

            modelBuilder.Entity<Skill>(skill =>
            {
                skill.HasKey(s => s.Id);
                skill.HasData(new List<Skill>()
                {
                    new Skill("C#") {Id = 1},
                    new Skill("Java") {Id = 2},
                    new Skill("Angular") {Id = 3},
                    new Skill("SQL") {Id = 4},
                    new Skill("ASP") {Id = 5}
                });
            });

            modelBuilder.Entity<Employee>(employee =>
            {
                employee.HasKey(e => e.Id);
                employee.HasOne(e => e.Gender);
            });

            modelBuilder.Entity<EmployeeSkill>(employeeSkill =>
            {
                employeeSkill.HasKey(es => new { es.EmployeeId, es.SkillId });
                employeeSkill.HasOne(es => es.Employee).WithMany(e => e.EmployeeSkills).HasForeignKey(es => es.EmployeeId);
                employeeSkill.HasOne(es => es.Skill).WithMany(s => s.Employees).HasForeignKey(es => es.SkillId);
            });         
                        
        }
    }
}
