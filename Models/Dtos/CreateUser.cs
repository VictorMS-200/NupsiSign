using System.ComponentModel.DataAnnotations;

namespace NupsiSign.Models.Dtos;

public class CreateUser
{
    [Required(ErrorMessage = "Username is required")]
    public string UserName { get; set; } = string.Empty;
    
    [EmailAddress(ErrorMessage = "The email field is must be a valid email address")]
    [Required(ErrorMessage = "Email is required")]
    public string Email { get; set; } = string.Empty;
    
    [DataType(DataType.Password)]
    [Required(ErrorMessage = "Password is required")]
    public string Password { get; set; } = string.Empty;
    
    [DataType(DataType.Password)]
    [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
    public string ConfirmPassword { get; set; } = string.Empty;
}