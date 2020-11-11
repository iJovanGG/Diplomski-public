using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DiplomskiMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Services.IServices;
using Services.DTOs;
using System.Security.Claims;
using Data.Entityes;
using Microsoft.AspNetCore.Authorization;
using Services.SearchQuerys;

namespace DiplomskiMVC.Controllers
{
    [Authorize]
    public class RequestController : Controller
    {
        private readonly IRequestService _requestService;
        public RequestController(IRequestService requestService)
        {
            _requestService = requestService;
            
        }

        [Authorize(Roles = "Student")]
        public async Task<IActionResult> MakeRequest(int id)
        {
            bool requestId = await _requestService.MakeRequest(new RequestDTO
            {
                Student = new FacultyStudentDTO { Id = User.FindFirst(ClaimTypes.NameIdentifier).Value },
                ThesisId = id,
                Status = (int)RequestStatus.Pending
            });
            if (!requestId)
                return BadRequest();
            else
                return Ok();
        }

        [Authorize(Roles = "Professor,Student")]
        public async Task<IActionResult> ShowRequests(RequestSearchQuery searchQuery)
        {
            _requestService.SetRequesterId(User.FindFirst(ClaimTypes.NameIdentifier).Value);

            if (User.FindFirst(ClaimTypes.Role).Value == "Student")
            {
                return View("ShowStudentRequests", (await _requestService.GetRequestsForStudent()).Select(r => (RequestView)r));
            }
            else if (User.FindFirst(ClaimTypes.Role).Value == "Professor")
            {
                PaginationView<RequestView, RequestSearchQuery> paginationView = new PaginationView<RequestView, RequestSearchQuery>
                {
                    TargetAction = ControllerContext.RouteData.Values["action"].ToString(),
                    TargetController = ControllerContext.RouteData.Values["controller"].ToString(),
                    SearchQuery = searchQuery
                };
                var serviceResult = await _requestService.GetAllRequestsForProfessor(searchQuery);
                paginationView.ObjectList = serviceResult.ObjectList.Select(e => (RequestView)e);
                paginationView.TotalCount = serviceResult.TotalCount;
                return View("ShowProfessorRequests", paginationView);
            }
            else
                return BadRequest();
        }

        [HttpPost]
        [Authorize(Roles = "Professor")]
        public async Task<IActionResult> DenyRequest(string response, int requestId)
        {
            _requestService.SetRequesterId(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            if (await _requestService.DenyRequest(requestId, response))
                return Ok();
            else
                return BadRequest();
        }

        [HttpPost]
        [Authorize(Roles = "Professor")]
        public async Task<IActionResult> ApproveRequest(string response, int requestId)
        {
            _requestService.SetRequesterId(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            if (await _requestService.ApproveRequest(requestId))
                return Ok();
            else
                return BadRequest();
        }
    }
}
