using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeRegister.DAL.Models
{
    public enum SexSign
    {
        F,
        M,
        ND
    }

    public class Sex : BaseModel
    {
        public SexSign Sign { get; private set; }
        public string Description { get; private set; }

        public Sex(SexSign sign, string description)
        {
            Sign = sign;
            Description = description;
        }
                
    }
}
