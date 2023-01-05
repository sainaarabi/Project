using Microsoft.EntityFrameworkCore;
using SSO.Core.Domain.AcademicYear; 
using SSO.Core.Domain.Course;
using SSO.Core.Domain.Teach;
using SSO.Core.Domain.Teacher;
using SSO.Core.Domain.TimeSchedule;
using SSO.Core.Domain.Unit;

namespace SSO.Infrastructure.DBContext
{
    public class SSODbContext : DbContext
    { 
       
        public virtual DbSet<Teacher> Teacher { get; set; }

        public virtual DbSet<Course> Course { get; set; }
        public virtual DbSet<AcademicYear> AcademicYear { get; set; }
        public virtual DbSet<Unit> Unit { get; set; }

        public virtual DbSet<TimeSchedule> TimeSchedule { get; set; }
        public virtual DbSet<Teach> Teach { get; set; }

        public SSODbContext(DbContextOptions<SSODbContext> options)
            : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
 
            modelBuilder.Entity<Teacher>(entity =>
            {
                entity.Property(p => p.ID).HasColumnType("int").IsRequired(true);
                entity.Property(p => p.FirstName).HasColumnType("nvarchar(100)").IsRequired(false);
                entity.Property(p => p.LastName).HasColumnType("nvarchar(100)").IsRequired(false); 

            });
            modelBuilder.Entity<Course>(entity =>
            {
                entity.Property(p => p.ID).HasColumnType("int").IsRequired(true);
                entity.Property(p => p.Name).HasColumnType("nvarchar(100)").IsRequired(false);
                entity.Property(p => p.CourseTypeId).HasColumnType("int").IsRequired(true);
                entity.Property(p => p.Vahed).HasColumnType("int").IsRequired(true);

            });

            modelBuilder.Entity<AcademicYear>(entity =>
            {
                entity.Property(p => p.ID).HasColumnType("int").IsRequired(true);
                entity.Property(p => p.Date).HasColumnType("nvarchar(100)").IsRequired(false);

            });
            modelBuilder.Entity<TimeSchedule>(entity =>
            {
                entity.Property(p => p.ID).HasColumnType("int").IsRequired(true);
                entity.Property(p => p.StartTime).HasColumnType("nvarchar(100)").IsRequired(false);
                entity.Property(p => p.EndTime).HasColumnType("nvarchar(100)").IsRequired(false);
                entity.Property(p => p.Day).HasColumnType("int").IsRequired(true);

            });
            modelBuilder.Entity<Unit>(entity =>
            {
                entity.Property(p => p.ID).HasColumnType("int").IsRequired(true); 
                entity.Property(p => p.CourseID).HasColumnType("int").IsRequired(true);
                entity.Property(p => p.AcademicYearID).HasColumnType("int").IsRequired(true);
                entity.Property(p => p.TimeScheduleID).HasColumnType("int").IsRequired(true);
                entity.HasOne(p => p.Course).WithMany(p => p.Units).HasForeignKey(p => p.CourseID).
                IsRequired(false).OnDelete(DeleteBehavior.Restrict); 
                entity.HasOne(p => p.AcademicYear).WithMany(p => p.Units).HasForeignKey(p => p.AcademicYearID).
                IsRequired(false).OnDelete(DeleteBehavior.Restrict);
                entity.HasOne(p => p.TimeSchedule).WithMany(p => p.Units).HasForeignKey(p => p.TimeScheduleID).
               IsRequired(false).OnDelete(DeleteBehavior.Restrict);

            });
            modelBuilder.Entity<Teach>(entity =>
            {
                entity.Property(p => p.ID).HasColumnType("int").IsRequired(true);
                entity.Property(p => p.TeacherID).HasColumnType("int").IsRequired(true);
                entity.Property(p => p.UnitID).HasColumnType("int").IsRequired(true); 
                entity.HasOne(p => p.Teacher).WithMany(p => p.Teachs).HasForeignKey(p => p.TeacherID).
                IsRequired(false).OnDelete(DeleteBehavior.Restrict);
                entity.HasOne(p => p.Unit).WithMany(p => p.Teachs).HasForeignKey(p => p.UnitID).
                IsRequired(false).OnDelete(DeleteBehavior.Restrict); 

            });
            //modelBuilder.Entity<ApplicationMenu>(entity =>
            //{
            //    entity.Property(p => p.ID).HasColumnType("int").IsRequired(true);
            //    entity.Property(p => p.Title).HasColumnType("nvarchar(150)").IsRequired(false);
            //    entity.Property(p => p.ParentID).HasColumnType("int").IsRequired(false);
            //    entity.Property(p => p.UniqueID).HasColumnType("nvarchar(150)").IsRequired(false);
            //    entity.Property(p => p.Link).HasColumnType("nvarchar(150)").IsRequired(false);
            //    entity.Property(p => p.Icon).HasColumnType("nvarchar(150)").IsRequired(false);
            //    entity.Property(p => p.NewPage).HasColumnType("bit").IsRequired(false);
            //    entity.Property(p => p.Priority).HasColumnType("int").IsRequired(true);
            //    entity.Property(p => p.ControlField).HasColumnType("nvarchar(200)").IsRequired(false);
            //    entity.Property(p => p.ShortcutKey).HasColumnType("nvarchar(150)").IsRequired(false);
            //    entity.Property(p => p.Active).HasColumnType("bit").IsRequired(false);
            //    entity.HasOne(p => p.Parent).WithMany(p => p.Childrens).HasForeignKey(p => p.ParentID).
            //        IsRequired(false).OnDelete(DeleteBehavior.Restrict);
            //    //entity.Property(p => p.ApplicationID).HasColumnType("smallint").IsRequired(false);
            //    //entity.Property(p => p.ApplicationModuleID).HasColumnType("int").IsRequired(false);
            //    //entity.Property(p => p.ActionsID).HasColumnType("int").IsRequired(false);
            //});




            //#region Comments
            //modelBuilder.Entity<Branch>(entity =>
            //{
            //    entity.Property(p => p.ID).HasColumnType("int").IsRequired(true);
            //    entity.Property(p => p.Title).HasColumnType("nvarchar(100)").IsRequired(false);
            //    entity.Property(p => p.Code).HasColumnType("nvarchar(50)").IsRequired(false);
            //    entity.Property(p => p.CustomerID).HasColumnType("smallint").IsRequired(false);
            //    entity.Property(p => p.ParentID).HasColumnType("int").IsRequired(false);
            //    entity.Property(p => p.HeadOfBranch).HasColumnType("nvarchar(100)").IsRequired(false);
            //    entity.Property(p => p.Address).HasColumnType("nvarchar(250)").IsRequired(false);
            //    entity.Property(p => p.PhoneNumberOne).HasColumnType("nvarchar(15)").IsRequired(false);
            //    entity.Property(p => p.PhoneNumberTwo).HasColumnType("nvarchar(15)").IsRequired(false);
            //    entity.Property(p => p.Fax).HasColumnType("nvarchar(15)").IsRequired(false);
            //    entity.Property(p => p.PostalCode).HasColumnType("nvarchar(10)").IsRequired(false);
            //    entity.Property(p => p.Description).HasColumnType("nvarchar(500)").IsRequired(false);
            //    entity.Property(p => p.Latitude).HasColumnType("varchar(100)").IsRequired(false);
            //    entity.Property(p => p.Longitude).HasColumnType("varchar(100)").IsRequired(false);

            //});
            //modelBuilder.Entity<Notification>(entity =>
            //{
            //    entity.Property(p => p.ID).HasColumnType("int").IsRequired(true);
            //    entity.Property(p => p.UserID).HasColumnType("bigint").IsRequired(false);
            //    entity.Property(p => p.NotfyText).HasColumnType("nvarchar(MAX)").IsRequired(false);
            //    entity.Property(p => p.Date).HasColumnType("datetime").IsRequired(false);
            //    entity.Property(p => p.Time).HasColumnType("nvarchar(10)").IsRequired(false);
            //    entity.Property(p => p.IsRead).HasColumnType("bit").IsRequired(false);
            //    entity.Property(p => p.Type).HasColumnType("tinyint").IsRequired(false);
            //    entity.Property(p => p.IsSend).HasColumnType("bit").IsRequired(true);

            //});
            //modelBuilder.Entity<OrganizationalStructure>(entity =>
            //{
            //    entity.Property(p => p.ID).HasColumnType("int").IsRequired(true);
            //    entity.Property(p => p.CustomerID).HasColumnType("smallint").IsRequired(false);
            //    entity.Property(p => p.Title).HasColumnType("nvarchar(200)").IsRequired(false);
            //    entity.Property(p => p.ParentID).HasColumnType("int").IsRequired(false);
            //    entity.Property(p => p.MultipleMember).HasColumnType("bit").IsRequired(false);
            //    entity.Property(p => p.Code).HasColumnType("nvarchar(50)").IsRequired(false);
            //});





            //modelBuilder.Entity<ApplicationPolicie>(entity =>
            //{
            //    entity.Property(p => p.ID).HasColumnType("int").IsRequired(true);
            //    entity.Property(p => p.PolicyName).HasColumnType("nvarchar(100)").IsRequired(false);
            //    entity.Property(p => p.PolicyCode).HasColumnType("nvarchar(100)").IsRequired(false);
            //    entity.Property(p => p.ApplicationID).HasColumnType("smallint").IsRequired(false);
            //    entity.Property(p => p.InitialValue).HasColumnType("nvarchar(200)").IsRequired(false);

            //});
            //modelBuilder.Entity<CustomerClaim>(entity =>
            //{
            //    entity.Property(p => p.ID).HasColumnType("int").IsRequired(true);
            //    entity.Property(p => p.ClaimValue).HasColumnType("nvarchar(200)").IsRequired(false);
            //    entity.Property(p => p.CustomerID).HasColumnType("smallint").IsRequired(false);
            //    entity.Property(p => p.PolicyID).HasColumnType("int").IsRequired(false);
            //    entity.Property(p => p.ApplicationID).HasColumnType("smallint").IsRequired(false);



            //modelBuilder.Entity<UserRequest>(entity =>
            //{
            //    entity.Property(p => p.ID).HasColumnType("int").IsRequired(true);
            //    entity.Property(p => p.CustomerID).HasColumnType("smallint").IsRequired(false);
            //    entity.Property(p => p.UserID).HasColumnType("bigint").IsRequired(false);
            //    entity.Property(p => p.Accepted).HasColumnType("bit").IsRequired(false);
            //    entity.Property(p => p.RequestDate).HasColumnType("date").IsRequired(false);



            //});
            //modelBuilder.Entity<UserRole>(entity =>
            //{
            //    entity.Property(p => p.ID).IsRequired(true);
            //    entity.Property(p => p.RoleID).HasColumnType("int").IsRequired(false);
            //    entity.Property(p => p.CustomerUserID).HasColumnType("bigint").IsRequired(false);

            //});
            //modelBuilder.Entity<PasswordLog>(entity =>
            //{
            //    entity.Property(p => p.ID).IsRequired(true);
            //    entity.Property(p => p.UserID).HasColumnType("bigint").IsRequired(false);
            //    entity.Property(p => p.UserName).HasColumnType("nvarchar(50)").IsRequired(false);
            //    entity.Property(p => p.CodeDate).HasColumnType("datetime").IsRequired(true);
            //    entity.Property(p => p.Enable).HasColumnType("bit").IsRequired(true);
            //    entity.Property(p => p.Code).HasColumnType("nvarchar(6)").IsRequired(true);
            //    // entity.Property(p => p.IsValidate).HasColumnType("bit").IsRequired(false);

            //});
            //modelBuilder.Entity<LoginLog>(entity =>
            //{
            //    entity.Property(p => p.ID).IsRequired(true);
            //    entity.Property(p => p.UserID).HasColumnType("bigint").IsRequired(true);
            //    entity.Property(p => p.Date).HasColumnType("datetime").IsRequired(true);
            //    entity.Property(p => p.IP).HasColumnType("nvarchar(50)").IsRequired(false);
            //    entity.Property(p => p.IsLogin).HasColumnType("bit").IsRequired(true);
            //    entity.Property(p => p.Time).HasColumnType("nvarchar(10)").IsRequired(true);
            //    entity.Property(p => p.Description).HasColumnType("nvarchar(500)").IsRequired(false);
            //    entity.Property(p => p.ApplicationName).HasColumnType("nvarchar(100)").IsRequired(false);
            //    entity.Property(p => p.IsFail).HasColumnType("bit").IsRequired(false);
            //    entity.Property(p => p.DeviceName).HasColumnType("nvarchar(200)").IsRequired(false);
            //    entity.Property(p => p.EventLogHash).HasColumnType("nvarchar(MAX)").IsRequired(false);
            //   // entity.Property(p => p.Mode).HasColumnType("bit").IsRequired(false);


            //});
            //modelBuilder.Entity<ExternalModule>(entity =>
            //{
            //    entity.Property(p => p.ID).IsRequired(true);
            //    entity.Property(p => p.Title).HasColumnType("nvarchar(50)").IsRequired(true);
            //    entity.Property(p => p.ExternalModuleID).HasColumnType("nvarchar(50)").IsRequired(true);
            //    entity.Property(p => p.ApplicationModuleID).HasColumnType("int").IsRequired(false);

            //});
            //modelBuilder.Entity<EventLog>(entity =>
            //{
            //    entity.Property(p => p.ID).IsRequired(true);
            //    entity.Property(p => p.Message).HasColumnType("nvarchar(MAX)").IsRequired(false);
            //    //entity.Property(p => p.[Level]).HasColumnType("nvarchar(128)").IsRequired(false);
            //    entity.Property(p => p.LogTimeStamp).HasColumnType("datetime").IsRequired(false);
            //    entity.Property(p => p.Exception).HasColumnType("nvarchar(MAX)").IsRequired(false);
            //    entity.Property(p => p.UserName).HasColumnType("nvarchar(50)").IsRequired(true);
            //    entity.Property(p => p.UserId).HasColumnType("bigint").IsRequired(true);
            //    entity.Property(p => p.ModuleCode).HasColumnType("nvarchar(200)").IsRequired(false);
            //    entity.Property(p => p.Operation).HasColumnType("nvarchar(50)").IsRequired(false);
            //    entity.Property(p => p.Url).HasColumnType("nvarchar(200)").IsRequired(true);
            //    entity.Property(p => p.IP).HasColumnType("nvarchar(20)").IsRequired(true);
            //    entity.Property(p => p.EventLogHash).HasColumnType("nvarchar(MAX)").IsRequired(false);
            //    //   entity.Property(p => p.Mode).HasColumnType("bit").IsRequired(false);


            //});




        }
    }
}



























//private readonly IMongoDatabase _db;
//public SSODbContext(string MongoDBConnectionString, string MongoDataBaseName)
//{
//    var client = new MongoClient(MongoDBConnectionString);
//    _db = client.GetDatabase(MongoDataBaseName);
//}
//public IMongoDatabase DB => _db;
//public IMongoCollection<Customer> Customer => _db.GetCollection<Customer>("Customers");
