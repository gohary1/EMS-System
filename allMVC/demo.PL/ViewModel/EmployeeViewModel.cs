using Demo.DAL.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;
using Microsoft.AspNetCore.Http;

namespace demo.PL.ViewModel
{
    public class EmployeeViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Name is Required")]
        [MaxLength(50, ErrorMessage = "max lenght for name is 50")]
        public string Name { get; set; }
        [Range(21, 60)]
        public int? Age { get; set; }

        public string Address { get; set; }
        [DataType(DataType.Currency)]
        public decimal Salary { get; set; }
        public bool IsActive { get; set; }
        [EmailAddress]
        [Required(ErrorMessage = "Email is Required")]
        public string Email { get; set; }
        [Required(ErrorMessage = "phone is Required")]
        public string PhoneNumber { get; set; }
        public DateTime HiringDare { get; set; }
        public IFormFile Image { get; set; }
        public string ImageName { get; set; }
        [ForeignKey("Department")]
        public int? dp_Id { get; set; }

        public Department Department { get; set; }
    }
}
