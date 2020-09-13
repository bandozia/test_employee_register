using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

using System.Threading.Tasks;

namespace EmployeeRegister.DAL.Models
{
    public class Skill : BaseModel
    {        
        public string Name { get; private set; }

        public Skill(string name)
        {
            Name = name;
        }

        public Skill()
        {
        }

        [JsonIgnore]
        public virtual ICollection<EmployeeSkill> Employees { get; set; }
    }

    public class EmployeeSkill
    {
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
        public int SkillId { get; set; }
        public Skill Skill { get; set; }
    }
}
