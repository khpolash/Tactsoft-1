using Tactsoft.Core.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Tactsoft.Core.Entities;

namespace Tactsoft.Core.Entities
{
    public class Employee : BaseEntity
    {

        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Middle Name")]
        public string MiddleName { get; set; }
        [Required]
        [Display(Name ="Last Name")]
        public string LastName { get; set; }
        [Required]
        [Display(Name =" Date Of Birth")]
        [Column(TypeName = "date")]
        public DateTime DateOfBirth { get; set; }
        public string NID { get; set; }
        [Required]
        [ForeignKey("Religion")]
        [Display(Name ="Religion")]
        public long? ReligionId { get; set; }
        
        [Required]
        [ForeignKey("MaritalStatus")]
        [Display(Name ="Marital Status")]
        public long? MaritialStatusId { get;set; }
        public string Nationalaty { get; set; }
        public string Picture { get; set; } 
        [Required]
        [ForeignKey("Gender")]
        [Display(Name ="Gender")]
        public long? GenderId { get; set; }
        [Required]
        [ForeignKey("Company")]
        [Display(Name = " Company Name")]
        public long? CompanyId { get; set; }
        [Display(Name = "Department")]
        public long? DepartmentId { get; set; }
        public Department Department { get; set; }
        [Required]
        [ForeignKey("Branch")]
        [Display(Name = "Branch Name")]
        public long BrancehId { get; set; }

        [Required]
        [ForeignKey("Project")]
        [Display(Name ="Project Name")]
        public long ProjectId { get; set;}
        [Required]
        [Display(Name ="Joining date")]
        public DateTime JoiningDate { get; set; }

        [Required]
        [Display(Name ="User Name")]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
        public Religion Religion { get; set; }
       
        public MaritialStatus MaritialStatus { get; set; }
        public CompanyInfo CompanyInfo { get; set; }
        public Gender Gender { get; set; }
        public BranchInfo BranchInfo { get; set; }
        public Project project { get; set; }
        public IList<ServiceInfo> ServiceInfos { get; set; }
        public IList<FamilyMember> FamilyMembers { get; set; }
        public IList<Attachment> Attachments { get;set; }
        public IList<Training> Trainings { get; set; }
        public IList<Education> Educations { get; set; }
        public IList<Award>Awards { get; set; }
        public IList<Attandance> Attandances { get; set;}
        public IList<LeaveApplication> LeaveApplications { get; set; }
        public IList<Nominee>Nominees { get; set; }
        public IList<Advance> Advances { get; set; }
        public IList<EmploymentHistory> EmploymentHistorys { get; set; }
        public IList<Attendance> Attendances { get; set; }
        public IList<ServiceInformation> ServiceInformations { get; set; }
        public IList<SalarySetup> SalarySetups { get; set; }
    }
}
