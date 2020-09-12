using EmployeeRegister.DAL.Models;
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

        //TODO: escrever o get paged
    }
}
