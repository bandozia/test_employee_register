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

            modelBuilder.Entity<Sex>(sex =>
            {
                sex.HasKey(s => s.Id);
                sex.Property(s => s.Sign).HasConversion(new EnumToStringConverter<SexSign>());

                sex.HasData(new Sex(SexSign.F, "Feminino") { Id = 1 });
                sex.HasData(new Sex(SexSign.M, "Masculino") { Id = 2 });
                sex.HasData(new Sex(SexSign.ND, "Prefio não responder") { Id = 3 });
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
                employee.HasOne(e => e.Sex);
            });

            modelBuilder.Entity<EmployeeSkill>(employeeSkill =>
            {
                employeeSkill.HasKey(es => new { es.EmployeeId, es.SkillId });
                employeeSkill.HasOne(es => es.Employee).WithMany(e => e.Skils).HasForeignKey(es => es.EmployeeId);
                employeeSkill.HasOne(es => es.Skill).WithMany(s => s.Employees).HasForeignKey(es => es.SkillId);
            });
                        
        }
    }
}
