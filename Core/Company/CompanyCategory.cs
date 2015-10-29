using System;
using System.Collections.Generic;

namespace Core.Company
{
    public partial class CompanyCategory : BaseEntity
    {
        public int ID { get; set; }
        public string Category { get; set; }
        public bool IsRemoved { get; set; }
    }
}
