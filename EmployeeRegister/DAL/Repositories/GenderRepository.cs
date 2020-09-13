using EmployeeRegister.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeRegister.DAL.Repositories
{
    public class GenderRepository : BaseRepository<Gender>
    {
        public GenderRepository(CoreContext context) : base(context)
        {
        }
    }
}
