using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using DiplomskiMVC.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Services.DTOs;
using Services.IServices;
using Services.SearchQuerys;

namespace DiplomskiMVC.Controllers
{
    [Authorize]
    public class ThesisController : Controller
    {
        private readonly IThesisService _thesisService;

        public ThesisController(IThesisService thesisService)
        {
            _thesisService = thesisService;
        }

        public async Task<IActionResult> ThesisSingle(int id)
        {
            ThesisView thesis = await _thesisService.GetThesisById(id);
            if (thesis == null)
                return NotFound();
            else
                return View(thesis);
        }


        [Authorize(Roles = "Professor")]
        public async Task<IActionResult> CreateThesis()
        {
            ThesisView thesis = await _thesisService.CreateThesisIfNeeded(User.FindFirstValue(ClaimTypes.NameIdentifier));
            return View("ThesisEditor", thesis);
        }

        [Authorize(Roles = "Professor")]
        public async Task<IActionResult> UploadImage(int thesisId, IFormFile image)
        {
            var result = await _thesisService.UploadThesisImage(thesisId, image);
            if (result.Success)
                return Ok(JsonConvert.SerializeObject(new { location = result.Result }));
            else
                return BadRequest(result.Result);
        }

        [Authorize(Roles = "Professor")]
        public async Task<IActionResult> UpdateThesis(int id)
        {
            ThesisView thesis = await _thesisService.GetThesisById(id);
            if (thesis != null)
                return View("ThesisEditor", thesis);
            else
                return NotFound();
        }

        [HttpPost]
        [Authorize(Roles = "Professor")]
        public async Task<IActionResult> UpdateThesis(ThesisView thesisView)
        {
            if (!ModelState.IsValid)
                return View("ThesisEditor", thesisView);
            thesisView.Professor = new FacultyProfessorView { Id = User.FindFirstValue(ClaimTypes.NameIdentifier) };
            ThesisView thesis = await _thesisService.PublishThesis(thesisView.ToThesisDTO());
            if (thesis != null)
                return RedirectToAction("UpdateThesis", "Thesis", new { id = thesis.Id });
            else
                return BadRequest();
        }

        [HttpPost]
        [Authorize(Roles = "Professor")]
        public async Task<IActionResult> SaveDraft(ThesisView thesisView)
        {
            if (!ModelState.IsValid)
                return View("ThesisEditor", thesisView);
            thesisView.Professor = new FacultyProfessorView { Id = User.FindFirstValue(ClaimTypes.NameIdentifier) };
            ThesisView thesis = await _thesisService.UpdateThesis(thesisView.ToThesisDTO());
            if (thesis != null)
                return RedirectToAction("UpdateThesis", "Thesis", new { id = thesis.Id });
            else
                return BadRequest();
        }

        [Authorize(Roles = "Professor")]
        public async Task<IActionResult> DeleteThesis(int id)
        {
            FunctionReturnDTO result = await _thesisService.DeleteThesis(id, User.FindFirstValue(ClaimTypes.NameIdentifier));
            if(result.Success)
            {
                return RedirectToAction("Browse", "Thesis");
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public async Task<IActionResult>AddComment(CommentView commentView)
        {
            commentView.User = new FacultyUserView { Id = User.FindFirstValue(ClaimTypes.NameIdentifier) };
            if (await _thesisService.AddComment(commentView.ToCommentDTO()))
                return RedirectToAction("ThesisSingle", new { id = commentView.Thesis.Id });
            else
                return BadRequest();
        }

        [HttpGet]
        public async Task<IActionResult>Browse(ThesisSearchQuery searchQuery)
        {
            if (User.FindFirst("ModuleId") != null)
            {
                int.TryParse(User.FindFirst("ModuleId").Value, out int moduleId);
                searchQuery.ModuleId = moduleId;
            }
                
            PaginationView<ThesisView, ThesisSearchQuery> paginationView = new PaginationView<ThesisView, ThesisSearchQuery>
            {
                TargetAction = ControllerContext.RouteData.Values["action"].ToString(),
                TargetController = ControllerContext.RouteData.Values["controller"].ToString(),
                SearchQuery = searchQuery
            };
            var serviceResult = await _thesisService.GetThesisSearchPage(searchQuery);
            paginationView.ObjectList = serviceResult.ObjectList.Select(e => (ThesisView)e);
            paginationView.TotalCount = serviceResult.TotalCount;
            return View(paginationView);
        }

    }
}
