using EmployeeRegister.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeRegister.DAL.Repositories
{
    public class EmployeeRepository : BaseRepository<Employee>
    {
        public EmployeeRepository(CoreContext context) : base(context)
        {
        }

        public override async Task<ICollection<Employee>> GetAll()
        {            
            return await DbSet.Include(e => e.EmployeeSkills)
                .ThenInclude(s => s.Skill)
                .Include(e => e.Gender).ToListAsync();
        }
        
    }
}
