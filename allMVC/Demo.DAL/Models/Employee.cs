using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.DAL.Models
{
    public class Employee:ModelBase
    {

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [Range(21,60)]
        public int? Age { get; set; }
        
        public string Address { get; set; }
        public decimal Salary { get; set; }
        public bool IsActive { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        public DateTime HiringDare { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreationDate { get; set; }
        public string ImageName { get; set; }
        [ForeignKey("Department")]
        public int? dp_Id { get; set; }

        public Department Department { get; set; }
    }
}
