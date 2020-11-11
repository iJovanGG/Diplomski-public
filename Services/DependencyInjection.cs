using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using Data.Context;
using Data.Entityes;
using Microsoft.AspNetCore.Identity;
using Services.IServices;
using Services.Services;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Amazon.Extensions.NETCore.Setup;
using Amazon.S3;
using Amazon.Runtime;

namespace Services
{
    public static class DependencyInjection
    {
        public static string S3Link { get; set; }
        public static string S3Bucket { get; set; }


        public static void AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            ///S3
            S3Link = configuration.GetSection("AWS").GetSection("BucketLink").Value;
            S3Bucket = configuration.GetSection("AWS").GetSection("BuketNameAndFolder").Value;

            AWSOptions awsOptions = configuration.GetAWSOptions();
            awsOptions.Credentials = new BasicAWSCredentials(configuration["AWS:AccessKey"], configuration["AWS:SecretKey"]);
            services.AddDefaultAWSOptions(awsOptions);
            services.AddAWSService<IAmazonS3>();

            services.AddDbContext<FacultyDBContext>(options => options.UseSqlServer(configuration.GetConnectionString("DiplomskiConnection")));

            //identity

            services.AddIdentityCore<FacultyUser>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 3;
                options.Password.RequiredUniqueChars = 0;
                options.Password.RequireNonAlphanumeric = false;
            })
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<FacultyDBContext>()
                .AddDefaultUI()
                .AddDefaultTokenProviders();
                


            services.AddDefaultIdentity<FacultyUser>(options => {
                options.Password.RequireDigit = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 3;
                options.Password.RequiredUniqueChars = 0;
                options.SignIn.RequireConfirmedAccount = false;

            })
                .AddRoles<IdentityRole>()
                .AddDefaultUI()
                .AddEntityFrameworkStores<FacultyDBContext>()
                .AddDefaultTokenProviders();

            services.AddMvc(config =>
            {

                config.EnableEndpointRouting = false;
                var policy = new AuthorizationPolicyBuilder()
                                 .RequireAuthenticatedUser()
                                 .Build();
                config.Filters.Add(new AuthorizeFilter(policy));
            });

            services.ConfigureApplicationCookie(options =>
            {
                options.AccessDeniedPath = "/User/AccessDenied";
                options.LoginPath = "/User/Login";
            });

            //services
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IModuleService, ModuleService>();
            services.AddScoped<ISubjectService, SubjectService>();
            services.AddScoped<IThesisService, ThesisService>();
            services.AddScoped<IRequestService, RequestService>();
        }

        public static void AddApplicationSettings(this IApplicationBuilder app)
        {
            app.UseAuthorization();
            app.UseAuthentication();

            
        }
    }
}
