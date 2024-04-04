using System.ComponentModel.DataAnnotations;

namespace Chat5.ViewModels
{
    public class RegisterVM
    {
        [Required(ErrorMessage ="Imię jest wymagane")]
        [Display(Name = "Imię użytkownika")]
        public string? NickName { get; set; }


        [Required(ErrorMessage = "Email jest wymagany")]
        [Display(Name ="Adres E-mail")]
        [DataType(DataType.EmailAddress)]
        public string? Email { get; set; }
        [Required(ErrorMessage = "Hasło jest wymagane")]
        [Display(Name="Hasło")]
        [DataType(DataType.Password)]
        public string? Password { get; set; }

        [Required(ErrorMessage = "Powtórz hasło")]
        [Compare("Password", ErrorMessage = "Hasła nie są identyczne.")]
        [Display(Name = "Potwierdz hasło")]
        [DataType(DataType.Password)]
        public string? ConfirmPassword { get; set; }

    


    }
}
