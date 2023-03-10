﻿using Tactsoft.Core.Entities;
using Tactsoft.Core.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Reflection;
using Tactsoft.Data.DbDependencies;
using Tactsoft.Core;
using Tactsoft.Core.Entities;
using Gender = Tactsoft.Core.Entities;

namespace Tactsoft.Service.DbDependencies
{
    public class AppDbContext:IdentityDbContext<ApplicationUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }


        #region Properties
        public DbSet<BloodGroup> BloodGroups { get; set; }
        public DbSet<BranchInfo> BranchInfos { get; set; }
        public DbSet<CompanyInfo> CompanyInfos { get; set; }
        public DbSet<MaritialStatus> MaritialStatuses { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Religion> Religions { get; set; }
        public DbSet<ZipCode> ZipCodes { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<State> States { get; set; }
        
        public DbSet<City> Cities { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Attachment> Attachments { get; set; }
        public DbSet<AttachmentType> AttachmentsType { get; set; }
        public DbSet<Degree> Degrees { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Designation> Designations { get; set; }
        public DbSet<Education> Educations { get; set; }
        public DbSet<EducationGroup> EducationGroups { get; set; }
        public DbSet<FamilyMember> FamilyMembers { get; set; }
        public DbSet<RelationShip> Relationships { get; set; }
        public DbSet<ServiceInfo> ServiceInfos { get; set; }
        public DbSet<Training> Trainings { get; set; }
        public DbSet<Award>Awards { get; set; }
        public DbSet<LeaveType> LeaveTypes { get; set; }
        public DbSet<AwardType> AwardTypes { get; set; }
        public DbSet<AllowanceSetting> AllowanceSettings { get; set; }
        public DbSet<Attandance> Attandances { get; set; }
        public DbSet<SalarySetup> SalarySetups { get; set; }
        public DbSet<Allowens> Allowenss { get; set; }
        public DbSet<AllowensDetails> AllowensDetailss { get; set; }
        public DbSet<Deduction> Deductions { get; set; }
        public DbSet<LeaveApplication> LeaveApplications { get; set; }
        public DbSet<Advance>Advances { get; set; }
        public DbSet<Reference> References { get; set; }
        public DbSet<AdvanceType> AdvanceTypes { get; set; }
        public DbSet<EmploymentHistory>EmploymentHistories { get; set; }
        public DbSet<Nominee> Nominees { get; set; }
        public DbSet<Attendance> Attendances { get; set; }
        public DbSet<ServiceInformation> ServiceInformations { get; set; }
        public DbSet<EmployeeType> EmployeeTypes { get; set; }






        #endregion



        #region Methods
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.LogTo(Console.WriteLine);
            optionsBuilder.LogTo(message => WriteSqlQueryLog(message));
            optionsBuilder.UseLoggerFactory(_myLoggerFactory);
        }

        public const string DefaultSchemaName = "dbo";
        public string Schema { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.HasDefaultSchema(Schema);
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            builder.RelationConvetion();
            builder.DecimalConvention();
            builder.DateTimeConvention();

            builder.Seed();
        }

        public static readonly Microsoft.Extensions.Logging.LoggerFactory _myLoggerFactory = new LoggerFactory(new[] {
            new Microsoft.Extensions.Logging.Debug.DebugLoggerProvider()
                //new ConsoleLoggerProvider((_, __) => true, true)
        });

        private void WriteSqlQueryLog(string query, StoreType storeType = StoreType.Output)
        {
            if (storeType == StoreType.Output)
                Debug.WriteLine(query);
            else if (storeType == StoreType.Db)
            {
                // store in db
            }
            else if (storeType == StoreType.File)
            {
                // store & append in file
                //new StreamWriter("mylog.txt", append: true);
            }

            //using (WebAppContext context = new WebAppContext())
            //{
            //    context.Database.Log = s => System.Diagnostics.Debug.WriteLine(s);
            //}

            //IQueryable queryable = from x in Blogs
            //                       where x.Id == 1
            //                       select x;

            //var sqlEf5 = ((System.Data.Objects.ObjectQuery)queryable).ToTraceString();
            //var sqlEf6 = ((System.Data.Entity.Core.Objects.ObjectQuery)queryable).ToTraceString();
            //var sql = queryable.ToString();

            // https://docs.microsoft.com/en-us/ef/ef6/fundamentals/logging-and-interception?redirectedfrom=MSDN
            // https://stackoverflow.com/questions/1412863/how-do-i-view-the-sql-generated-by-the-entity-framework
        }

        #endregion

        
    }

    public enum StoreType
    {
        Db,
        File,
        Output
    }
}
