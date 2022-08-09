using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace EducationPortal.Context
{
    public class EducationPortalDBContext : DbContext
    {
        public EducationPortalDBContext() : base()
        {
        }

        public EducationPortalDBContext(DbContextOptions<EducationPortalDBContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                   .SetBasePath(Directory.GetCurrentDirectory())
                   .AddJsonFile("appsettings.json")
                   .Build();
                //var connectionString = configuration.GetConnectionString("PMISWeb_Connection");
                optionsBuilder.UseMySql(configuration.GetConnectionString("EducationPortal_Connection"), ServerVersion.Parse("8.0.22"));
            }
        }

        public DbSet<EducationPortal.Models.tblUser> tblUser { get; set; }
        public DbSet<EducationPortal.Models.tblRole> tblRole { get; set; }
        public DbSet<EducationPortal.Models.tblCMS> tblCMS { get; set; }
        public DbSet<EducationPortal.Models.tblSuggest> tblSuggest { get; set; }
        public DbSet<EducationPortal.Models.tblSlider> tblSlider { get; set; }
        public DbSet<EducationPortal.Models.tblBlog> tblBlog { get; set; }
        public DbSet<EducationPortal.Models.tblEmailSendHistory> tblEmailSendHistory { get; set; }
        public DbSet<EducationPortal.Models.tblRecipient> tblRecipient { get; set; }
        public DbSet<EducationPortal.Models.tblSpecialization> tblSpecialization { get; set; }
        public DbSet<EducationPortal.Models.tblCourseInquiry> tblCourseInquiry { get; set; }
        public DbSet<EducationPortal.Models.tblCollegeCourse> tblCollegeCourse { get; set; }
        public DbSet<EducationPortal.Models.tblCollegeSemester> tblCollegeSemester { get; set; }
        public DbSet<EducationPortal.Models.tblCategory> tblCategory { get; set; }
        public DbSet<EducationPortal.Models.tblCollege> tblCollege { get; set; }
        public DbSet<EducationPortal.Models.tblNewsLetter> tblNewsLetter { get; set; }
        public DbSet<EducationPortal.Models.tblDesignation> tblDesignation { get; set; }
        public DbSet<EducationPortal.Models.tblCourse> tblCourse { get; set; }
        public DbSet<EducationPortal.Models.tblTemplate> tblTemplate { get; set; }
        public DbSet<EducationPortal.Models.tblMenuItem> tblMenuItem { get; set; }
        public DbSet<EducationPortal.Models.tblRolePrivilege> tblRolePrivilege { get; set; }
    }
}
