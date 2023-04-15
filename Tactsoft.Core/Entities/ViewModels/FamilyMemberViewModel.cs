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
    public class FamilyMemberViewModel:MasterEntity
    {
           
        public string FamilyMemberName { get; set; }
      
        public long? RelationShipId { get; set; }
       
        public string ContactNumber { get; set; }
    
        public string Address { get; set; }
    }
}
