using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tactsoft.Core.Base;

namespace Tactsoft.Core.Entities
{
    public class RelationShip:BaseEntity
    {
        [Display(Name ="Relationship")]
        public string RelationShipName { get; set; }
        public IList<FamilyMember> FamilyMembers { get; set; }
        public IList<Nominee>Nominees { get; set; }
    }
}
