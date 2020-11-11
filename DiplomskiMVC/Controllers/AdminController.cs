using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DiplomskiMVC.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.IServices;

namespace DiplomskiMVC.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly IModuleService _moduleService;
        private readonly ISubjectService _subjectService;
        public AdminController(IModuleService moduleService, ISubjectService subjectService)
        {
            _moduleService = moduleService;
            _subjectService = subjectService;
        }

        public async Task<IActionResult> Subjects()
        {
            return View((await _moduleService.GetAllModuleDTOs(true)).Select(e=>(ModuleView)e));
        }

        public async Task<IActionResult> CreateSubject(SubjectView subject)
        {
            SubjectView result = await _subjectService.CreateSubjectDTO(subject.ToSubjectDTO());
            if (result == null)
                return BadRequest();
            return PartialView("_SubjectCard", result);
        }

        public async Task<IActionResult> GetSubjectEditModal(int id)
        {
            SubjectView result = await _subjectService.GetSubjectDTO(id);
            if (result == null)
                return BadRequest();
            return PartialView("_EditSubjectModal", result);
        }

        [HttpPost]
        public async Task<IActionResult> AddProfessorToSubject(string professorId, int subjectId)
        {
            if(await _subjectService.AddProfessorToSubject(professorId, subjectId))
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
