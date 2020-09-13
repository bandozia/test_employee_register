using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeRegister.DAL.Models
{
    public enum GenderSign
    {
        F,
        M,
        ND
    }

    public class Gender : BaseModel
    {
        [Column(TypeName = "nvarchar(4)")]
        public GenderSign Sign { get; private set; }

        public string Description { get; private set; }

        public Gender(GenderSign sign, string description)
        {
            Sign = sign;
            Description = description;
        }

        public Gender()
        {
        }
                
    }
}
