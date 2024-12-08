using AcademicShare.Web.Context;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NupsiSign.Models.DbSet;
using NupsiSign.Services;

namespace NupsiSign.Controllers;

[Authorize]
public class DocumentationController : Controller
{
    private readonly NupsiSignDbContext _context;
    private readonly UserManager<User> _userManager;
    private readonly QuestionService _questionService;
    private readonly IWebHostEnvironment _hostEnvironment;

    public DocumentationController(UserManager<User> userManager, QuestionService questionService, NupsiSignDbContext context, IWebHostEnvironment hostEnvironment)
    {
        _context = context;
        _userManager = userManager;
        _questionService = questionService;
        _hostEnvironment = hostEnvironment;
    }

    [HttpGet]
    public async Task<IActionResult> FormAsync()
    {
        var questions = await _questionService.GetQuestions();
        ViewBag.Questions = questions;
        return View();
    }
    
    [ValidateAntiForgeryToken]
    [HttpPost]
    public async Task<IActionResult> FormAsync(Data data, IFormCollection form)
    {
        var user = await _userManager.GetUserAsync(User);
        
        var dataUser = await _context.Data.FirstOrDefaultAsync(x => x.Id == user.DataId);
        
        dataUser.marrigeCelebrated = form["The marriage will be celebrated"];
        dataUser.propertyRegime = form["Property Regime adopted by the couple"];
        dataUser.Groom.fullName = form["Groom's full name"];
        dataUser.Groom.nameMarriage = form["Name to be used after the Marriage"];
        dataUser.Groom.maritalStatus = form["Groom's Marital Status"];
        dataUser.Groom.phone = form["Groom's Phone (Enter NUMBERS ONLY to work.)"];
        dataUser.Groom.profession = form["Groom's Profession"];
        dataUser.Groom.email = form["Groom's Email"];
        dataUser.Groom.fatherFullName = form["Groom's Father's Full Name"];
        dataUser.Groom.fatherDateOfBirth = form["Groom's Father's Date of Birth"];
        dataUser.Groom.motherFullName = form["Groom's Mother's Full Name"];
        dataUser.Groom.motherDateOfBirth = form["Groom's Mother's Date of Birth"];
        dataUser.Bride.fullName = form["Bride's Full Name"];
        dataUser.Bride.nameMarriage = form["Name to be used after the Marriage"];
        dataUser.Bride.maritalStatus = form["Bride's Marital Status"];
        dataUser.Bride.phone = form["Bride's Phone (Enter NUMBERS ONLY to work.)"];
        dataUser.Bride.profession = form["Bride's Profession"];
        dataUser.Bride.email = form["Bride's Email"];
        dataUser.Bride.fatherFullName = form["Bride's Father's Full Name"];
        dataUser.Bride.fatherDateOfBirth = form["Bride's Father's Date of Birth"];
        dataUser.Bride.motherFullName = form["Bride's Mother's Full Name"];
        dataUser.Bride.motherDateOfBirth = form["Bride's Mother's Date of Birth"];
        dataUser.FirstWitness.fullName = form["Full Name of the 1st Witness"];
        dataUser.FirstWitness.maritalStatus = form["Marital Status of the 1st Witness"];
        dataUser.FirstWitness.profession = form["Profession of the 1st Witness"];
        dataUser.FirstWitness.dateOfBirth = form["Date of Birth of the 1st Witness"];
        dataUser.FirstWitness.document = form["ID Document and issuing authority of the 1st Witnessss"];
        dataUser.FirstWitness.documentNumber = form["CPF of the 1st Witness"];
        dataUser.FirstWitness.address = form["Full Address of the 1st Witness"];
        dataUser.SecondWitness.fullName = form["Full Name of the 2nd Witness"];
        dataUser.SecondWitness.maritalStatus = form["Marital Status of the 2nd Witness"];
        dataUser.SecondWitness.profession = form["Profession of the 2nd Witness"];
        dataUser.SecondWitness.dateOfBirth = form["Date of Birth of the 2nd Witness"];
        dataUser.SecondWitness.document = form["ID Document and issuing authority of the 2nd Witness"];
        dataUser.SecondWitness.documentNumber = form["CPF of the 2nd Witness"];
        dataUser.SecondWitness.address = form["Full Address of the 2nd Witness"];
        
        _context.Update(dataUser);
        await _context.SaveChangesAsync();
        
        return RedirectToAction("Index", "Home");
    }
    
    [HttpGet]
    public async Task<IActionResult> IndexAsync()
    {
        var user = await _userManager.GetUserAsync(User);
        return View(user);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> IndexAsync(User userModel)
    {
        if (ModelState.IsValid)
        {
            string BirthCertificate;
            string IdentificationGuardians;
            string MarriageCertificate;
            string InitialPetition;
            string AddressProofDocumentation;

            BirthCertificate = await CreateFile(userModel.Documentation.BirthCertificateFile, "BirthCertificate");
            IdentificationGuardians =
                await CreateFile(userModel.Documentation.IdentificationGuardiansFile, "IdentificationGuardians");
            MarriageCertificate = await CreateFile(userModel.Documentation.MarriageCertificateFile, "MarriageCertificate");
            InitialPetition = await CreateFile(userModel.Documentation.InitialPetitionFile, "InitialPetition");
            AddressProofDocumentation = await CreateFile(userModel.Documentation.AddressProofDocumentationFile,
                "AddressProofDocumentation");

            var user = await _userManager.GetUserAsync(User);
            
            user.Documentation.BirthCertificate = BirthCertificate;
            user.Documentation.IdentificationGuardians = IdentificationGuardians;
            user.Documentation.MarriageCertificate = MarriageCertificate;
            user.Documentation.InitialPetition = InitialPetition;
            user.Documentation.AddressProofDocumentation = AddressProofDocumentation;

            _context.Update(user);
            await _context.SaveChangesAsync();

            return RedirectToAction("Form", "Documentation");
        }
        else
        {
            return View(userModel);
        }
    }
    
    public async Task<string> CreateFile(
        IFormFile file, 
        string pathString)
    {
        string fileName;

        if (file is null) return string.Empty;

        var wwwRootPath = _hostEnvironment.WebRootPath;
        fileName = Guid.NewGuid().ToString() + "_" + file.FileName;
        var path = Path.Combine(wwwRootPath + "/" + pathString, fileName);

        using (var fileStream = new FileStream(path, FileMode.Create))
        {
            await file.CopyToAsync(fileStream);
        }
        return fileName;
    }
    
}