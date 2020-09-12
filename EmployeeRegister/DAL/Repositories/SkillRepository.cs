using EmployeeRegister.DAL.Models;
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
    }
}
