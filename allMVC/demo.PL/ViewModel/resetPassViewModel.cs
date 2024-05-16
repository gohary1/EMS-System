using System.ComponentModel.DataAnnotations;

namespace demo.PL.ViewModel
{
    public class resetPassViewModel
    {
        public string Email { get; set; }
        public string token { get; set; }
        [Required(ErrorMessage = "Pass is Required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Compare(nameof(Password),ErrorMessage ="Password doesn't Match")]
        [DataType(DataType.Password)]
        public string confirmPass { get; set; }
    }
}
