using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tactsoft.Core.Base;

namespace Tactsoft.Core.Entities
{
    public class AllowanceSetting:BaseEntity
    {
        public string valuePercetize { get; set; }
        public Double Value { get; set; }
        [EnumDataType(typeof(Allowance))]
        public Allowance AllowanceType { get; set; }
    }
}
