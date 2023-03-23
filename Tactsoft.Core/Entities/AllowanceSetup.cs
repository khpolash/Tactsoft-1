using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tactsoft.Core.Base;

namespace Tactsoft.Core.Entities
{
    public class AllowanceSetup:BaseEntity
    {
        public string ValuePercetize { get; set; }
        public double Value { get; set; } 
        public AllowanceType AllowanceType { get;set; }
    }
}
