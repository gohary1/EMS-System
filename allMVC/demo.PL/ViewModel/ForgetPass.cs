using System.ComponentModel.DataAnnotations;

namespace demo.PL.ViewModel
{
    public class ForgetPass

    {
        [Required(ErrorMessage ="Email is Required!")]
        [EmailAddress(ErrorMessage ="Email is Not Valid")]
        public string Email { get; set; }
    }
}
