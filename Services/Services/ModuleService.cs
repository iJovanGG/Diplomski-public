using Services.DTOs;
using Services.IServices;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Data.Context;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Services.Services
{
    public class ModuleService : IModuleService
    {
        private readonly FacultyDBContext _context;
        public ModuleService(FacultyDBContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<ModuleDTO>> GetAllModuleDTOs(bool includeSubjects)
        {
            if (includeSubjects)
                return await _context.Modules
                    .Include(e => e.SubjectsList)
                    .ThenInclude(e=>e.ProfessorSubjectsList)
                    .ThenInclude(e=>e.FacultyProfessor)
                    .Select(e => (ModuleDTO)e).ToArrayAsync();
            else
                return await _context.Modules.Select(e => (ModuleDTO)e).ToArrayAsync();
        }

        public async Task<IEnumerable<FacultyProfessorDTO>> GetProfessorsForModule(int moduleId)
        {
            if (moduleId != 0)
                return await _context.FacultyProfessors
                    .Where(p => _context.ProfessorSubjects.Where(s => s.Subject.ModuleId == moduleId).Select(s => s.ProfessorId).Contains(p.Id))
                    .Select(p=>(FacultyProfessorDTO)p)
                    .ToArrayAsync();
            else
                return await _context.FacultyProfessors
                    .Select(p => (FacultyProfessorDTO)p)
                    .ToArrayAsync();
        }

        public async Task<IEnumerable<SubjectDTO>> GetSubjectsForModule(int moduleId)
        {
            if(moduleId != 0)
                return await _context.Subjects.Where(s => s.ModuleId == moduleId)
                    .Select(s => (SubjectDTO)s)
                    .ToArrayAsync();
            else
                return await _context.Subjects
                    .Select(s => (SubjectDTO)s)
                    .ToArrayAsync();
        }
    }
}
