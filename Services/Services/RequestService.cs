using Amazon.Runtime.Internal.Util;
using Data.Context;
using Data.Entityes;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Services.DTOs;
using Services.IServices;
using Services.SearchQuerys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    class RequestService : IRequestService
    {
        private readonly FacultyDBContext _context;
        private readonly ILogger<RequestService> _logger;
        private string RequesterId;

        public RequestService(FacultyDBContext context, ILogger<RequestService> logger)
        {
            _context = context;
            _logger = logger;
        }
        public async Task<bool> ApproveRequest(int requestId)
        {
            try
            {
                Request request = await _context.Requests
                    .Include(r => r.Thesis)
                    .ThenInclude(t => t.Professor)
                    .Where(r => r.Id == requestId && r.Status == (int)RequestStatus.Pending)
                    .FirstOrDefaultAsync();
                if (request.Thesis.Professor.Id != RequesterId)
                    return false;

                request.Status = (int)RequestStatus.Accepted;
                _context.Requests.Update(request);
                IEnumerable<Request> toDeny = await _context.Requests
                    .Where(r => r.ThesisId == request.ThesisId && r.Id != requestId && r.Status == (int)RequestStatus.Pending)
                    .ToArrayAsync();
                foreach (Request r in toDeny)
                    r.Status = (int)RequestStatus.TakenBySomeoneElse;

                Thesis thesis = await _context.Theses.FindAsync(request.ThesisId);
                thesis.DateTaken = DateTime.Now;

                FacultyStudent assignedStudent = await _context.FacultyStudents.FindAsync(request.StudentId);
                assignedStudent.AsignedThesis = thesis;

                _context.FacultyStudents.Update(assignedStudent);
                _context.Theses.Update(thesis);

                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogInformation("Failed denying request: " + ex.Message);
                return false;
            }
        }

        public async Task<bool> CancelRequest(int requestId)
        {
            try
            {
                Request request = await _context.Requests
                    .Where(r => r.Id == requestId)
                    .FirstOrDefaultAsync();
                if (request.StudentId != RequesterId && request.Status != (int)RequestStatus.Pending)
                    return false;
                request.Status = (int)RequestStatus.Canceled;
                _context.Requests.Update(request);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogInformation("Failed canceling request: " + ex.Message);
                return false;
            }
        }

        public async Task<bool> DenyRequest(int requestId, string response)
        {
            try
            {
                Request request = await _context.Requests
                    .Include(r => r.Thesis)
                    .ThenInclude(t => t.Professor)
                    .Where(r => r.Id == requestId)
                    .FirstOrDefaultAsync();
                if (request.Thesis.Professor.Id != RequesterId && request.Status == (int)RequestStatus.Pending)
                    return false;
                request.Status = (int)RequestStatus.Denied;
                request.Response = response;
                _context.Requests.Update(request);
                await _context.SaveChangesAsync();
                return true;
            }
            catch(Exception ex)
            {
                _logger.LogInformation("Failed denying request: " + ex.Message);
                return false;
            }
        }

        public async Task<PaginationDTO<RequestDTO, RequestSearchQuery>> GetAllRequestsForProfessor(RequestSearchQuery query)
        {
            IQueryable<Request> queryBuilder = _context.Requests
                .Include(r=>r.Thesis)
                .Include(r=>r.Student)
                .Where(r => r.Thesis.Professor.Id == RequesterId);
            switch (query.OrderBy)
            {
                case RequestsOrderBy.DatePosted:
                    queryBuilder = query.OrderAscending ? queryBuilder.OrderBy(x => x.DateCreated) 
                        : queryBuilder.OrderByDescending(x => x.DateCreated);
                    break;
                case RequestsOrderBy.ThesisId:
                    queryBuilder = query.OrderAscending ? queryBuilder.OrderBy(x => x.ThesisId)
                        : queryBuilder.OrderByDescending(x => x.ThesisId);
                    break;
                case RequestsOrderBy.Status:
                    queryBuilder = query.OrderAscending ? queryBuilder.OrderBy(x => x.Status)
                        : queryBuilder.OrderByDescending(x => x.Status);
                    break;
            }
            if (query.HideCompleted)
                queryBuilder = queryBuilder.Where(x => x.Status == (int)RequestStatus.Pending);

            PaginationDTO<RequestDTO, RequestSearchQuery> paginationResult = new PaginationDTO<RequestDTO, RequestSearchQuery>
            {
                TotalCount = await queryBuilder.CountAsync(),
                SearchQuery = query
            };

            if(query.PerPage > 0)
            {
                queryBuilder = queryBuilder.Skip(query.PerPage * (query.Page - 1))
                    .Take(query.PerPage);
            }

            paginationResult.ObjectList = await queryBuilder.Select(e => (RequestDTO)e).ToArrayAsync();

            return paginationResult;
        }

        public async Task<bool> MakeRequest(RequestDTO requestDTO)
        {
            try
            {
                int check = _context.Requests.Where(r => r.StudentId == requestDTO.Student.Id && r.Status == (int)RequestStatus.Pending).Count();
                if (check > 0)
                    return false;

                Request request = requestDTO.ToRequest();
                request.DateCreated = DateTime.Now;
                _context.Attach(request.Student);
                _context.Requests.Add(request);
                await _context.SaveChangesAsync();
                return true;
            }
            catch(Exception ex)
            {
                _logger.LogInformation("Failed adding request: " + ex.Message);
                return false;
            }
        }

        public async Task<bool> CanStudentRequest(string studentId)
        {
            int check = await _context.Requests
                .Where(r => r.StudentId == studentId && (r.Status == (int)RequestStatus.Pending || r.Status == (int)RequestStatus.Accepted))
                .CountAsync();
            if (check > 0)
                return false;
            else
                return true;
        }

        public void SetRequesterId(string userId)
        {
            RequesterId = userId;
        }

        public async Task<IEnumerable<RequestDTO>> GetRequestsForStudent()
        {
            IEnumerable<RequestDTO> resultDTOs = await _context.Requests
                .Where(r => r.StudentId == RequesterId)
                .Include(t => t.Thesis)
                .Select(r => (RequestDTO)r)
                .ToArrayAsync();
            return resultDTOs;
        }

        public async Task<int> NumberOfUnhandledRequests(string professorId)
        {
            return await _context.Requests
                .Where(r => r.Thesis.Professor.Id == professorId && r.Status == (int)RequestStatus.Pending)
                .CountAsync();
        }
    }
}
