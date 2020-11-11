using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Services.IServices;
using DiplomskiMVC.Models;
using Microsoft.AspNetCore.Authorization;

namespace DiplomskiMVC.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }


        [AllowAnonymous]
        [Authorize(Roles = "Admin")]
        public IActionResult RegisterStudent()
        {
            return View(new RegistrationFieldsStudent());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> RegisterStudent(RegistrationFieldsStudent info)
        {
            if (ModelState.IsValid)
            {
                var result = await _userService.RegisterStudent(info.ToRegistrationDTO());
                if (!result.Succeeded)
                {
                    foreach (var error in result.Errors)
                        ModelState.AddModelError(error.Code, error.Description);
                    return View(info);
                }
                return RedirectToAction("RegisterStudent", "User");
            }
            return View(info);
        }

        [AllowAnonymous]
        [Authorize(Roles = "Admin")]
        public IActionResult RegisterProfessor()
        {
            return View(new RegistrationFieldsProfessor());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> RegisterProfessor(RegistrationFieldsProfessor info)
        {
            if (ModelState.IsValid)
            {
                var result = await _userService.RegisterProfessor(info.ToRegistrationDTO());
                if (!result.Succeeded)
                {
                    foreach (var error in result.Errors)
                        ModelState.AddModelError(error.Code, error.Description);
                    return View(info);
                }
                return RedirectToAction("RegisterProfessor", "User");
            }
            return View(info);
        }

        [AllowAnonymous]
        public IActionResult Login()
        {
            if (User.Identity.IsAuthenticated)
                return RedirectToAction("Index", "Home");
            return View(new LoginFields());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginFields info)
        {
            if(User.Identity.IsAuthenticated)
                return RedirectToAction("Browse", "Thesis");
            if (ModelState.IsValid)
            {
                var result = await _userService.LoginUser(info.Email, info.Password);
                if (!result.Succeeded)
                {
                    ModelState.AddModelError("Greška", "Pogrešna email adresa ili šifra");
                    return View(info);
                }
                return RedirectToAction("Browse", "Thesis");
            }
            return View(info);
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await _userService.LogoutUser();
            return RedirectToAction("Login", "User");
        }


        public async Task<IEnumerable<FacultyProfessorView>> GetAllUnassignedProfessorsForSubject(int id)
        {
            return (await _userService.GetAllUnassignedProfessorsForSubject(id)).Select(e=>(FacultyProfessorView)e);
        }

        public async Task<IActionResult> ProfessorProfile(string id)
        {
            FacultyProfessorView result = await _userService.GetProfessorById(id);
            if (result != null)
                return View(result);
            else
                return NotFound();
        }

        public async Task<IActionResult> StudentProfile(string id)
        {
            FacultyStudentView result = await _userService.GetStudentById(id);
            if (result != null)
                return View(result);
            else
                return NotFound();
        }
    }
}
