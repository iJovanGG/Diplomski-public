using Data.Context;
using Data.Entityes;
using Microsoft.EntityFrameworkCore;
using Services.DTOs;
using Services.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public class SubjectService : ISubjectService
    {
        private readonly FacultyDBContext _context;
        public SubjectService(FacultyDBContext context)
        {
            _context = context;
        }

        public async Task<bool> AddProfessorToSubject(string professorId, int subjectId)
        {
            try
            {
                ProfessorSubject professorSubject = new ProfessorSubject { ProfessorId = professorId, SubjectId = subjectId };
                _context.Attach(new FacultyProfessor { Id = professorId });
                _context.Attach(new Subject { Id = subjectId });
                _context.ProfessorSubjects.Add(professorSubject);
                await _context.SaveChangesAsync();
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
            

        }

        public async Task<SubjectDTO> CreateSubjectDTO(SubjectDTO subjectDto)
        {
            try
            {
                Subject newSubject = subjectDto.ToSubject();
                _context.Attach(new Module { Id = subjectDto.ModuleId });
                await  _context.Subjects.AddAsync(newSubject);
                await _context.SaveChangesAsync();
                subjectDto.Id = newSubject.Id;
                return subjectDto;
            }
            catch(Exception ex)
            {
                return null;
            }
        }

        public  async Task<SubjectDTO> GetSubjectDTO(int id)
        {
            return await _context.Subjects.Where(s=>s.Id == id)
                .Include(s=>s.ProfessorSubjectsList)
                .ThenInclude(p=>p.FacultyProfessor)
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<SubjectDTO>> GetSubjectsByModuleId(int moduleId)
        {
            return await _context.Subjects.Where(x => x.ModuleId == moduleId)
                .Include(x=>x.ProfessorSubjectsList)
                .ThenInclude(x=>x.FacultyProfessor)
                .Select(x=>(SubjectDTO)x)
                .ToArrayAsync();
        }

        public async Task<IEnumerable<SubjectDTO>> GetSubjectsByProfessorId(string professorId)
        {
            return await _context.ProfessorSubjects.Where(x => x.ProfessorId == professorId)
                .Include(x => x.Subject)
                .Select(x => (SubjectDTO)x.Subject)
                .ToArrayAsync();
        }

        public async Task<bool> RemoveProfessorFromSubject(string professorId, int subjectId)
        {
            try
            {
                _context.ProfessorSubjects.Remove(new ProfessorSubject{ ProfessorId = professorId, SubjectId = subjectId });
                await _context.SaveChangesAsync();
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
            

        }
    }
}
