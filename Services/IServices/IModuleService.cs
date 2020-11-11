using Services.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Services.IServices
{
    public interface IModuleService
    {
        Task<IEnumerable<ModuleDTO>> GetAllModuleDTOs(bool includeSubjects);
        Task<IEnumerable<FacultyProfessorDTO>> GetProfessorsForModule(int moduleId);
        Task<IEnumerable<SubjectDTO>> GetSubjectsForModule(int moduleId);
    }
}
