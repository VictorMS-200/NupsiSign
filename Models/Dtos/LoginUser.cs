using System.ComponentModel.DataAnnotations;

namespace NupsiSign.Models.Dtos;

public class LoginUser
{
    [EmailAddress(ErrorMessage = "The email field is must be a valid email address")]
    [Required(ErrorMessage = "Email is required")]
    public string Email { get; set; } = string.Empty;
    
    [DataType(DataType.Password)]
    [Required(ErrorMessage = "Password is required")]
    public string Password { get; set; } = string.Empty;
}