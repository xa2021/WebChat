using System.ComponentModel.DataAnnotations;

namespace Chat5.ViewModels
{
    public class LoginVM
    {
        [Required(ErrorMessage = "Login jest wymagany!")]
        [Display(Name = "Login (e-mail)")]
        public string? UserName { get; set; }

     
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Podaj hasło!")]
        [Display(Name = "Hasło")]
        public string? Password { get; set; }


        [Display(Name = "Zapamiętaj mnie")]
        public bool RememberMe { get; set; }

    }
}
