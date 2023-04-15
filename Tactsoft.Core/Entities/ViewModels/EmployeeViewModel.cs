using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Tactsoft.Core.Entities.Base;

namespace Tactsoft.Core.Entities.ViewModels
{
    public class EmployeeViewModel:MasterEntity
    {
     
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string NID { get; set; }
        public string  Religion { get; set; }
        public string MaritialStatus { get; set; }
        public string Nationalaty { get; set; }
        public string Picture { get; set; }
        public string Gender { get; set; }
        public string  Company { get; set; }
        public string Department { get; set; }
        
        public string Branceh { get; set; }
        public string  Project { get; set; }
        public DateTime JoiningDate { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }


        

    }
}
