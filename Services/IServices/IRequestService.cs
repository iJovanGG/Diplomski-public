using Data.Entityes;
using Services.DTOs;
using Services.SearchQuerys;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Services.IServices
{
    public interface IRequestService
    {
        void SetRequesterId(string userId);
        Task<bool> MakeRequest(RequestDTO request);
        Task<bool> CancelRequest(int requestId);
        Task<bool> ApproveRequest(int requestId);
        Task<bool> DenyRequest(int requestId, string response);
        Task<PaginationDTO<RequestDTO, RequestSearchQuery>> GetAllRequestsForProfessor(RequestSearchQuery query);
        Task<bool> CanStudentRequest(string studentId);
        Task<IEnumerable<RequestDTO>> GetRequestsForStudent();
        Task<int> NumberOfUnhandledRequests(string professorId);
    }
}
