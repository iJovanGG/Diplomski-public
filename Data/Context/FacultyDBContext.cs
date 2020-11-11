using Data.Entityes;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Data.Context
{
    public class FacultyDBContext : IdentityDbContext<FacultyUser, IdentityRole, string>
    {
        public FacultyDBContext(DbContextOptions<FacultyDBContext> options) : base(options)
        {

        }

        public FacultyDBContext() { }

        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=Diplomski;Trusted_Connection=True;MultipleActiveResultSets=true;");
        }
        

        public DbSet<FacultyUser> FacultyUsers { get; set; }
        public DbSet<FacultyStudent> FacultyStudents { get; set; }
        public DbSet<FacultyProfessor> FacultyProfessors { get; set; }
        public DbSet<FacultyAdmin> FacultyAdmins { get; set; }
        public DbSet<Module> Modules { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<ProfessorSubject> ProfessorSubjects { get; set; }
        public DbSet<Thesis> Theses { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Request> Requests { get; set; }

        public async Task<int> SaveChangesAsync()
        {
            return await base.SaveChangesAsync();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<FacultyUser>()
                .HasDiscriminator<int>(fu => fu.UserType)
                .HasValue<FacultyUser>(0)
                .HasValue<FacultyAdmin>(1)
                .HasValue<FacultyProfessor>(2)
                .HasValue<FacultyStudent>(3);

            builder.Entity<Subject>()
                .HasIndex(s => s.Name)
                .IsUnique(true);

            builder.Entity<Subject>()
                .HasOne(s => s.Module)
                .WithMany(m => m.SubjectsList)
                .HasForeignKey(s => s.ModuleId)
                .IsRequired();
            builder.Entity<Subject>()
                .HasMany(s => s.Theses)
                .WithOne(t => t.Subject);

            builder.Entity<ProfessorSubject>()
                .HasKey(ps => new { ps.ProfessorId, ps.SubjectId });
            builder.Entity<ProfessorSubject>()
                .HasOne(ps => ps.FacultyProfessor)
                .WithMany(p => p.ProfessorSubjectsList)
                .HasForeignKey(ps => ps.ProfessorId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
            builder.Entity<ProfessorSubject>()
                .HasOne(ps => ps.Subject)
                .WithMany(s => s.ProfessorSubjectsList)
                .HasForeignKey(ps => ps.SubjectId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Thesis>()
                .HasOne(t => t.Professor)
                .WithMany(p => p.Theses);

            builder.Entity<Comment>()
                .HasOne(c => c.Thesis)
                .WithMany(t => t.Comments);
            builder.Entity<Comment>()
                .HasOne(c => c.User)
                .WithMany(u => u.Comments);

            builder.Entity<Request>()
                .Property(r => r.DateCreated)
                .ValueGeneratedOnAdd();
            builder.Entity<Request>()
                .HasOne(s => s.Student)
                .WithMany(r => r.Requests)
                .HasForeignKey(r => r.StudentId);

            builder.Entity<Request>()
                .HasOne(r => r.Thesis)
                .WithMany(t => t.Requests)
                .HasForeignKey(r => r.ThesisId);


            builder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Id = "332b9243-01a6-4876-8452-9468528ccc06",
                Name = "Student",
                NormalizedName = "STUDENT"
            },
            new IdentityRole
            {
                Id = "476bd608-8ee8-410a-a470-9fce574a6112",
                Name = "Admin",
                NormalizedName = "ADMIN"
            },
            new IdentityRole
            {
                Id = "9bd53dcf-4bb8-4946-9d16-98ce31a0d87e",
                Name = "Professor",
                NormalizedName = "PROFESSOR"
            });

            builder.Entity<FacultyAdmin>().HasData(
                new FacultyAdmin
                {
                    Id = "476bd608-8ee8-410a-a470-9fce574a6112",
                    Email = "admin@admin.com",
                    UserName = "admin@admin.com",
                    NormalizedUserName = "admin@admin.com".ToUpper(),
                    NormalizedEmail = "admin@admin.com".ToUpper(),
                    EmailConfirmed = true,
                    PasswordHash = new PasswordHasher<FacultyAdmin>().HashPassword(null, "admin")
                }
            );

            builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                UserId = "476bd608-8ee8-410a-a470-9fce574a6112",
                RoleId = "476bd608-8ee8-410a-a470-9fce574a6112"
            });

            builder.Entity<Module>().HasData(
                new Module { Id = 1, Name = "Elektroenergetika" },
                new Module { Id = 2, Name = "Elektrotehnika i računarstvo" },
                new Module { Id = 3, Name = "Elektronika" },
                new Module { Id = 4, Name = "Elektronske komponente i mikrosistemi" },
                new Module { Id = 5, Name = "Upravljanje sistemima" },
                new Module { Id = 6, Name = "Komunikacije i informacione tehnologije" }
            );
        }
    }
}
