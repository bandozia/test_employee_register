using EmployeeRegister.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeRegister.DAL.Repositories
{
    public class SkillRepository : BaseRepository<Skill>
    {
        public SkillRepository(CoreContext context) : base(context)
        {
        }

        public async Task RemoveAllSkillsOfEmployee(int employeeId)
        {
            var joinTable = Context.Set<EmployeeSkill>();
            var skills = await joinTable.Where(es => es.EmployeeId == employeeId).ToListAsync();
            joinTable.RemoveRange(skills);
            await Context.SaveChangesAsync();
        }
    }
}
