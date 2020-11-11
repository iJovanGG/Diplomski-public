using Data.Entityes;
using Microsoft.AspNetCore.Identity;
using Services.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Services.IServices
{
    public interface IUserService
    {
        Task<IdentityResult> RegisterStudent(RegistrationDTO userInfo);
        Task<IdentityResult> RegisterProfessor(RegistrationDTO userInfo);
        Task<FacultyUserDTO> GetUserById(string id);
        Task<FacultyProfessorDTO> GetProfessorById(string id);
        Task<FacultyStudentDTO> GetStudentById(string id);
        Task<SignInResult> LoginUser(string username, string password);
        Task LogoutUser();
        Task<IEnumerable<FacultyProfessorDTO>> GetAllUnassignedProfessorsForSubject(int subjectId);
    }
}
