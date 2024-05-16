using System.ComponentModel.DataAnnotations;

namespace demo.PL.ViewModel
{
    public class SignupViewModel
    {
        [Required(ErrorMessage ="first Name is Required")]
        public string Fname { get; set; }
        [Required(ErrorMessage ="Last Name is Required")]
        public string Lname { get; set; }
        [Required(ErrorMessage ="Email is Required")]
        [EmailAddress(ErrorMessage ="Invalid email")]
        public string Email { get; set; }
        [Required(ErrorMessage ="Password is Required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required(ErrorMessage ="Confirm Password is Required")]
        [Compare(nameof(Password),ErrorMessage ="Doesn't Match password")]
        [DataType(DataType.Password)]
        public string ConfirmPass { get; set; }
        [Required(ErrorMessage ="Required to Agree")]
        public bool IsAgree { get; set; }
    }
}
