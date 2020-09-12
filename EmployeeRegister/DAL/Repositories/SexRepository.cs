using EmployeeRegister.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeRegister.DAL.Repositories
{
    public class SexRepository : BaseRepository<Sex>
    {
        public SexRepository(CoreContext context) : base(context)
        {
        }
    }
}
