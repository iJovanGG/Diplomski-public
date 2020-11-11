using Amazon.S3;
using Amazon.S3.Transfer;
using Data.Entityes;
using Microsoft.AspNetCore.Http;
using Services.DTOs;
using Services.IServices;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Data.Context;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Amazon.Runtime.Internal.Util;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc;
using Amazon.S3.Model;
using Services.SearchQuerys;

namespace Services.Services
{
    public class ThesisService : IThesisService
    {

        private readonly IAmazonS3 _awsS3;
        private readonly FacultyDBContext _context;
        private readonly ILogger<ThesisService> _logger;
        public ThesisService(IAmazonS3 amazonS3, 
            FacultyDBContext context,
            ILogger<ThesisService> logger)
        {
            _awsS3 = amazonS3;
            _context = context;
            _logger = logger;
        }

        public async Task<ThesisDTO> GetThesisById(int id)
        {
            return await _context.Theses
                    .Where(t => t.Id == id)
                    .Include(t => t.Professor)
                    .Include(t=>t.Subject)
                    .Include(t=>t.Comments)
                    .ThenInclude(c=>c.User)
                    .FirstOrDefaultAsync();
        }

        public async Task<ThesisDTO> CreateThesisIfNeeded(string professorId)
        {
            try
            {
                ThesisDTO exists = await _context.Theses
                    .Where(t => t.Professor.Id == professorId && t.Title == null)
                    .Include(t=>t.Professor)
                    .FirstOrDefaultAsync();
                if (exists != null)
                    return exists;
                FacultyProfessor prof = new FacultyProfessor { Id = professorId };
                _context.Attach(prof);
                Thesis newThesis = new Thesis { Professor = prof, DateCreated = DateTime.Now };
                _context.Theses.Add(newThesis);
                await _context.SaveChangesAsync();
                return newThesis;
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                return null;
            }
        }

        public async Task<ThesisDTO> UpdateThesis(ThesisDTO thesisDTO)
        {
            try
            {
                Thesis thesis = await _context.Theses
                    .Include(t => t.Subject)
                    .Include(t => t.Professor)
                    .Include(t=>t.Comments)
                    .Where(t => t.Id == thesisDTO.Id)
                    .FirstOrDefaultAsync();

                if (thesis.Professor.Id != thesisDTO.Professor.Id)
                {
                    _logger.LogInformation("Unathorized attempt to update thesis " + thesis.Id + " by user " + thesisDTO.Professor.Id);
                    return null;
                }
                if(thesis.DateTaken != null)
                {
                    _logger.LogInformation("Caanot update already taken thesis");
                    return null;
                }

                if (thesis.DateCreated == null)
                    thesis.DateCreated = DateTime.Now;
                else
                    thesis.DateUpdated = DateTime.Now;
                thesis.Discription = thesisDTO.Discription;
                thesis.ShortDescription = thesisDTO.ShortDescription;
                thesis.Title = thesisDTO.Title;
                if(thesis.Subject == null || thesis.Subject.Id != thesisDTO.Subject.Id)
                {
                    Subject newSubject = thesisDTO.Subject.ToSubject();
                    _context.Attach(newSubject);
                    thesis.Subject = newSubject;
                }
                await _context.SaveChangesAsync();
                return thesis;
            }
            catch(Exception ex)
            {
                _logger.LogInformation(ex.Message);
                return null;
            }
            
        }

        public async Task<ThesisDTO> PublishThesis(ThesisDTO thesisDTO)
        {
            try
            {
                Thesis thesis = await _context.Theses
                    .Include(t => t.Subject)
                    .Include(t => t.Professor)
                    .Where(t => t.Id == thesisDTO.Id)
                    .FirstOrDefaultAsync();

                if (thesis.Professor.Id != thesisDTO.Professor.Id)
                {
                    _logger.LogInformation("Unathorized attempt to update thesis " + thesis.Id + " by user " + thesisDTO.Professor.Id);
                    return null;
                }

                if (thesis.DateCreated == null)
                    thesis.DateCreated = DateTime.Now;
                else
                {
                    thesis.DateUpdated = DateTime.Now;
                }
                thesis.DatePublished = DateTime.Now;

                thesis.Discription = thesisDTO.Discription;
                thesis.ShortDescription = thesisDTO.ShortDescription;
                thesis.Title = thesisDTO.Title;
                if (thesis.Subject == null || thesis.Subject.Id != thesisDTO.Subject.Id)
                {
                    Subject newSubject = thesisDTO.Subject.ToSubject();
                    _context.Attach(newSubject);
                    thesis.Subject = newSubject;
                }
                await _context.SaveChangesAsync();
                return thesis;
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.Message);
                return null;
            }
        }

        public async Task<FunctionReturnDTO> UploadThesisImage(int thesisId, IFormFile image)
        {
            try
            {
                if (!new List<string> { ".jpg", ".jpeg", ".png", ".gif" }.Contains(Path.GetExtension(image.FileName)))
                {
                    return new FunctionReturnDTO { Success = false, Result = "File type not allowed" };
                }
                if (image.Length / (1024 * 1024) >= 1)
                {
                    return new FunctionReturnDTO { Success = false, Result = "File cannot be larger than 1MB" };
                }

                MemoryStream memoryStream = new MemoryStream();

                image.CopyTo(memoryStream);

                string fileName = "thesis/"+ thesisId + "/" + DateTime.Now.ToString("ddMMyyyyHHmmss") + Path.GetExtension(image.FileName);

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
            catch (Exception ex)
            {
                return new FunctionReturnDTO { Success = false, Result = ex.Message };
            }
        }

        public async Task<FunctionReturnDTO> DeleteThesis(int id, string professorId)
        {
            try
            {
                Thesis thesisToDelete = await _context.Theses
                    .Include(t => t.Professor)
                    .Where(t => t.Id == id)
                    .FirstOrDefaultAsync();

                if (thesisToDelete == null)
                    return new FunctionReturnDTO { Success = false, Result = "Thesis not found" };
                if (thesisToDelete.DateTaken != null)
                {
                    _logger.LogInformation("Unathorized attempt to delete thesis " + thesisToDelete.Id + " by user " + professorId);
                    return new FunctionReturnDTO { Success = false, Result = "Unauthorised" };
                }
                if (thesisToDelete.DateTaken != null)
                {
                    _logger.LogInformation("Cannot delete taken thesis");
                    return new FunctionReturnDTO { Success = false, Result = "Thesis already taken" };
                }

                DeleteObjectsRequest deleteRequest = new DeleteObjectsRequest();
                ListObjectsRequest listRequest = new ListObjectsRequest
                {
                    BucketName = DependencyInjection.S3Bucket,
                    Prefix = "thesis/" + thesisToDelete.Id + "/"
                };
                ListObjectsResponse response = await _awsS3.ListObjectsAsync(listRequest);
                if(response != null && response.S3Objects.Count > 0)
                {
                    foreach (S3Object entry in response.S3Objects)
                    {
                        deleteRequest.AddKey(entry.Key);
                    }
                    deleteRequest.BucketName = DependencyInjection.S3Bucket;
                    DeleteObjectsResponse deleteResponse = await _awsS3.DeleteObjectsAsync(deleteRequest);
                    if (deleteResponse.HttpStatusCode != System.Net.HttpStatusCode.OK)
                        return new FunctionReturnDTO { Success = false, Result = "Failed to delete images" };
                }
                

                _context.Theses.Remove(thesisToDelete);
                    await _context.SaveChangesAsync();
                    return new FunctionReturnDTO { Success = true };
            }
            catch(Exception ex)
            {
                _logger.LogInformation("Cannot delete thesis: " + ex.Message);
                return new FunctionReturnDTO { Success = false, Result = ex.Message };
            }
        }

        public async Task<bool> AddComment(CommentDTO commentDTO)
        {
            try
            {
                Comment comment = commentDTO.ToComment();
                _context.Attach(comment.User);
                _context.Attach(comment.Thesis);
                comment.Posted = DateTime.Now;
                _context.Comments.Add(comment);
                await _context.SaveChangesAsync();
                return true;
            }
            catch(Exception ex)
            {
                _logger.LogInformation("Cannot post comment: " + ex.Message);
                return false;
            }
        }

        public async Task<PaginationDTO<ThesisDTO, ThesisSearchQuery>> GetThesisSearchPage(ThesisSearchQuery searchQuery)
        {
            IQueryable<Thesis> queryBuilder = _context.Theses.Where(t => t.Subject.ModuleId == searchQuery.ModuleId)
                .Include(t => t.Subject)
                .Include(t => t.Professor);
            PaginationDTO<ThesisDTO, ThesisSearchQuery> returnPagination = new PaginationDTO<ThesisDTO, ThesisSearchQuery>();
            if (searchQuery.ProfessorId.Count > 0)
                queryBuilder = queryBuilder.Where(e => searchQuery.ProfessorId.Contains(e.Professor.Id));
            if(searchQuery.SubjectId.Count > 0)
                queryBuilder = queryBuilder.Where(e => searchQuery.SubjectId.Contains(e.Subject.Id));
            if (searchQuery.Title != null && searchQuery.Title != "")
                queryBuilder = queryBuilder.Where(e => e.Title.Contains(searchQuery.Title));
            if (searchQuery.HideTaken)
                queryBuilder = queryBuilder.Where(e => e.DateTaken == null);

            returnPagination.TotalCount = await queryBuilder.CountAsync();

            if(searchQuery.PerPage != -1)
                queryBuilder = queryBuilder
                    .Skip(searchQuery.PerPage * (searchQuery.Page - 1))
                    .Take(searchQuery.PerPage);

            returnPagination.ObjectList = await queryBuilder.Select(e => (ThesisDTO)e).ToArrayAsync();
            returnPagination.SearchQuery = searchQuery;

            return returnPagination;
        }
    }
}
