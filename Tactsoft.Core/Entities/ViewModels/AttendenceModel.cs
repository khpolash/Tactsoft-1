using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tactsoft.Core.Entities.ViewModels
{
    public class AttendenceModel
    {
        public AttendenceModel()
        {
            AttendenceList = new Collection<AttendenceList>();
            AttendenceDate=DateTime.Now;
        }
        [Required]
        [DisplayName("Department")]
        public int DepartmentId { get; set; }

        [Required]
        [DisplayName("Attendence Date")]
        public DateTime AttendenceDate { get; set; }
        public ICollection<AttendenceList> AttendenceList { get; set;}
    }
    public class AttendenceList
    {
        public long AttendenceId { get; set; }
        public long EmployeeId { get; set; }
        public string Name { get; set; }
        public Boolean IsPresent { get; set; }
    }
}
