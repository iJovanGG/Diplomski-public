using Microsoft.AspNetCore.Http;
using Services.DTOs;
using Services.SearchQuerys;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Services.IServices
{
    public interface IThesisService
    {
        Task<ThesisDTO> GetThesisById(int id);
        Task<ThesisDTO> CreateThesisIfNeeded(string professorId);
        Task<ThesisDTO> UpdateThesis(ThesisDTO thesis);
        Task<ThesisDTO> PublishThesis(ThesisDTO thesis);
        Task<FunctionReturnDTO> UploadThesisImage(int thesisId, IFormFile image);
        Task<FunctionReturnDTO> DeleteThesis(int id, string professorId);
        Task<bool> AddComment(CommentDTO commentDTO);
        Task<PaginationDTO<ThesisDTO, ThesisSearchQuery>> GetThesisSearchPage(ThesisSearchQuery searchQuery);

    }
}
