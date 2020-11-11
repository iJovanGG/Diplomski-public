using Data.Entityes;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Services.DTOs;
using Services.IServices;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Data.Context;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using Microsoft.Extensions.FileProviders;
using Microsoft.AspNetCore.Http;
using System.IO;
using Amazon.S3.Transfer;
using Amazon.S3;
using Amazon.S3.Model;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Services.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<FacultyUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<FacultyUser> _signInManager;
        private readonly ILogger<UserService> _logger;
        private readonly FacultyDBContext _context;
        private readonly IAmazonS3 _awsS3;
        public UserService(UserManager<FacultyUser> userManager, 
            SignInManager<FacultyUser> signInManager, 
            ILogger<UserService> logger, 
            RoleManager<IdentityRole> roleManager,
            FacultyDBContext context,
            IAmazonS3 awsS3)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _context = context;
            _roleManager = roleManager;
            _awsS3 = awsS3;
        }

        public async Task<FacultyUserDTO> GetUserById(string id)
        {
            return await _context.FacultyUsers.FindAsync(id);
        }

        public async Task<IdentityResult> RegisterStudent(RegistrationDTO userInfo)
        {
            FunctionReturnDTO uploadResult = null;
            if (userInfo.ProfileImage != null)
            {
                uploadResult = await UploadImage(userInfo.Email, userInfo.ProfileImage);
                if (!uploadResult.Success)
                {
                    return IdentityResult.Failed(new IdentityError[] { new IdentityError { Code = "Upload error", Description = uploadResult.Result } });
                }
            }

            FacultyStudent facultyUser = new FacultyStudent
            {
                FullName = userInfo.FullName,
                Email = userInfo.Email,
                UserName = userInfo.Email,
                Index = userInfo.Index,
                ProfileImageUrl = uploadResult == null ? null : uploadResult.Result,
                Module = new Module { Id = userInfo.ModuleId }
            };

            _context.Attach(facultyUser.Module);
            IdentityResult result = await _userManager.CreateAsync(facultyUser, userInfo.Password);
            if (!result.Succeeded)
                return result;


            await _userManager.AddClaimAsync(facultyUser, new Claim("ModuleId", userInfo.ModuleId.ToString()));
            await _userManager.AddToRoleAsync(facultyUser, "Student");

            return result;
        }

        public async Task<IdentityResult> RegisterProfessor(RegistrationDTO userInfo)
        {
            FunctionReturnDTO uploadResult = null; 

            if(userInfo.ProfileImage != null)
            {
                uploadResult = await UploadImage(userInfo.Email, userInfo.ProfileImage);
                if (!uploadResult.Success)
                {
                    return IdentityResult.Failed(new IdentityError[] { new IdentityError { Code = "Upload error", Description = uploadResult.Result } });
                }
            }
                

            FacultyProfessor facultyProfessor = new FacultyProfessor
            {
                FullName = userInfo.FullName,
                Email = userInfo.Email,
                UserName = userInfo.Email,
                ProfileImageUrl = uploadResult == null ? null : uploadResult.Result,
                Office = userInfo.Office
            };

            IdentityResult result = await _userManager.CreateAsync(facultyProfessor, userInfo.Password);
            if (!result.Succeeded)
                return result;

            await _userManager.AddToRoleAsync(facultyProfessor, "Professor");

            return result;
        }

        public async Task<SignInResult> LoginUser(string username, string password)
        {
            var result = await _signInManager.PasswordSignInAsync(username, password, false, lockoutOnFailure: false);
            if (result.Succeeded)
            {
                _logger.LogInformation("User logged in.");
            }
            else
            {
                _logger.LogInformation("Sign in Error.");
            }
            return result;
        }

        public async Task LogoutUser()
        {
            await _signInManager.SignOutAsync();
        }

        public async Task<FunctionReturnDTO> UploadImage(string userName, IFormFile image)
        {
            try
            {
                if (!new List<string> { ".jpg", ".jpeg", ".png", ".gif" }.Contains(Path.GetExtension(image.FileName)))
                {
                    return new FunctionReturnDTO { Success = false, Result = "File type not allowed" };
                }
                if(image.Length / (1024*1024) >= 1)
                {
                    return new FunctionReturnDTO { Success = false, Result = "File cannot be larger than 1MB" };
                }

                MemoryStream memoryStream = new MemoryStream();

                image.CopyTo(memoryStream);

                string fileName = "users/" + userName + "/profileimage/" + DateTime.Now.ToString("ddMMyyyyHHmm") + Path.GetExtension(image.FileName);

                var uploadRequest = new TransferUtilityUploadRequest
                {
                    InputStream = memoryStream,
                    Key = fileName,
                    BucketName = DependencyInjection.S3Bucket,
                    CannedACL = S3CannedACL.PublicRead
                };

                var fileTransferUtility = new TransferUtility(_awsS3);
                await fileTransferUtility.UploadAsync(uploadRequest);
                return new FunctionReturnDTO { Success = true, Result = DependencyInjection.S3Link + fileName };
            }
            catch(Exception ex)
            {
                _logger.LogInformation(ex.Message);
                return new FunctionReturnDTO { Success = false, Result = ex.Message };
            }
            
        }

        public async Task<bool> DeleteImage(string imageURL)
        {
            try
            {
                DeleteObjectRequest request = new DeleteObjectRequest
                {
                    BucketName = DependencyInjection.S3Bucket,
                    Key = imageURL.Replace(DependencyInjection.S3Link, "")
                };

                await _awsS3.DeleteObjectAsync(request);
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.Message);
                return false;
            }
        }

        public async Task<IEnumerable<FacultyProfessorDTO>> GetAllUnassignedProfessorsForSubject(int subjectId)
        {
            return await _context.FacultyProfessors
                .Except(_context.ProfessorSubjects.Where(p => p.SubjectId == subjectId).Select(e => e.FacultyProfessor))
                .Select(e => (FacultyProfessorDTO)e).ToArrayAsync();
        }

        public async Task<FacultyProfessorDTO> GetProfessorById(string id)
        {
            return await _context.FacultyProfessors
                .Where(p => p.Id == id)
                .Include(p=>p.ProfessorSubjectsList)
                .ThenInclude(s=>s.Subject)
                .Include(p=>p.Theses)
                .ThenInclude(t=>t.Subject)
                .FirstOrDefaultAsync();
        }

        public async Task<FacultyStudentDTO> GetStudentById(string id)
        {
            return await _context.FacultyStudents
                .Where(s => s.Id == id)
                .Include(s => s.AsignedThesis)
                .FirstOrDefaultAsync();
        }

    }
}
