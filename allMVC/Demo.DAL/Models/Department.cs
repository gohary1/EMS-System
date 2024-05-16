
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.DAL.Models
{
    public class Department:ModelBase
    {

        [Required(ErrorMessage ="code is required")]
        public string Code { get; set; }
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }
        [Display(Name="Date of creation")]
        public DateTime DateOfCreation { get; set; }

        public ICollection<Employee> employees { get; set; } =new HashSet<Employee>();

    }
}
