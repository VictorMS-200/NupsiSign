using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NupsiSign.Models.DbSet;

namespace NupsiSign.Controllers;

public class RegisterConstroller : Controller
{
    private readonly UserManager<User> _userManager;
    
    public RegisterConstroller(UserManager<User> userManager)
    {
        _userManager = userManager;
    }
    
    [HttpGet]
    public IActionResult Register()
    {
        return View();
    }
    
    [ValidateAntiForgeryToken]
    [HttpPost]
    
    
}