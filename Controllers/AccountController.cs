using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NupsiSign.Models.DbSet;
using NupsiSign.Models.Dtos;

namespace NupsiSign.Controllers;

public class AccountController : Controller
{
    private readonly UserManager<User> _userManager;
    private readonly SignInManager<User> _signInManager;
    private readonly IMapper _mapper;

    public AccountController(UserManager<User> userManager, SignInManager<User> signInManager, IMapper mapper)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _mapper = mapper;
    }
    
    [HttpGet]
    public IActionResult Register()
    {
        return View();
    }
    
    [ValidateAntiForgeryToken]
    [HttpPost]
    public async Task<IActionResult> Register([Bind(include:"UserName,Email,Password,ConfirmPassword")] CreateUser user)
    {
        
        if (ModelState.IsValid)
        {
            var emailIsInUse = await _userManager.FindByEmailAsync(user.Email!);

            if (emailIsInUse is not null)
            {
                ModelState.AddModelError(string.Empty, "Email is already in use");
                return View(user);
            }
            
            var newUser = _mapper.Map<User>(user);
            
            var result = await _userManager.CreateAsync(newUser, user.Password);
            
            if (result.Succeeded)
            {
                _signInManager.SignInAsync(newUser, false).Wait();
                return RedirectToAction("Index", "Home");
            }
            
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
        }
        
        return View(user);
    }
    
    [HttpGet]
    public IActionResult Login()
    {
        return View();
    }
    
    [ValidateAntiForgeryToken]
    [HttpPost]
    public async Task<IActionResult> Login(LoginUser user)
    {
        if (ModelState.IsValid)
        {
            var userExists = await _userManager.FindByEmailAsync(user.Email);
            
            if (userExists is null)
            {
                ModelState.AddModelError(string.Empty, "Invalid login attempt");
                return View(user);
            }

            if (userExists.UserName != null)
            {
                var result = await _signInManager.PasswordSignInAsync(userExists.UserName, user.Password, false, false);
            
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
            }

            ModelState.AddModelError(string.Empty, "Invalid login attempt");
        }
        
        return View(user);
    }
    
    [HttpGet]
    public IActionResult Information(string id)
    {
        return View();
    } 
    
    public async Task<IActionResult> Logout()
    {
        await _signInManager.SignOutAsync();
        return RedirectToAction("Index", "Home");
    }
}