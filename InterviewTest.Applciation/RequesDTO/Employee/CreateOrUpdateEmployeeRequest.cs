using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewTest.Applciation.RequesDTO.Employee
{
    public class CreateOrUpdateEmployeeRequest
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [MaxLength(50)]
        [EmailAddress]
        public string Email { get; set; }

        [MaxLength(50)]
        public string Department { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}
