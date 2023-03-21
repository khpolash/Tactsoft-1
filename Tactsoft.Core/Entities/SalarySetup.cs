﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tactsoft.Core.Base;

namespace Tactsoft.Core.Entities
{
    public class SalarySetup:BaseEntity
    {
        public long EmployeeId { get;set; }
        public Employee Employee { get;set; }
        public long AllowanceDeductionId { get; set; }  
        public AllowanceDeduction AllowanceDeduction { get; set; }
        public Boolean IsPercent { get; set; }
        public double Value { get; set; }
    }
}
