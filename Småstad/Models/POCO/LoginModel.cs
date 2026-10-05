using System.ComponentModel.DataAnnotations;
namespace Småstad.Models.POCO
{
  public class LoginModel
  {
    [Required(ErrorMessage = "Vänligen ange användarnamn")]
    [Display(Name = "Användarnamn")]
    public string? UserName { get; set; }
    [Required(ErrorMessage = "Vänligen ange lösenord")]
    [Display(Name = "Lösenord")]
    [DataType(DataType.Password)]
    public string? Password { get; set; }
    public string? ReturnUrl { get; set; }
  }
}
