using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeRegister.DAL.Models
{
    public class Employee : BaseModel
    {
        [Required]
        public string FirstName { get; set; }
        
        [Required]
        public string LastName { get; set; }

        [Required]        
        public DateTime BirthDate { get; set; }              
        
        [Required]
        public Gender Gender { get; set; }

        public string Email { get; set; }              
                
        public ICollection<EmployeeSkill> EmployeeSkills { get; set; }

        [NotMapped]
        public ICollection<Skill> Skills { get; set; }
    }
}
