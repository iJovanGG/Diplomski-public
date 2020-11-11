using Services.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Services.IServices
{
    public interface ISubjectService
    {
        Task<SubjectDTO> CreateSubjectDTO(SubjectDTO subject);
        Task<bool> AddProfessorToSubject(string professorId, int subjectId);
        Task<bool> RemoveProfessorFromSubject(string professorId, int subjectId);
        Task<SubjectDTO> GetSubjectDTO(int id);
        Task<IEnumerable<SubjectDTO>> GetSubjectsByModuleId(int moduleId);
        Task<IEnumerable<SubjectDTO>> GetSubjectsByProfessorId(string professorId);
    }
}
