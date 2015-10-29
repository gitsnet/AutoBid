using System;
using System.Collections.Generic;

namespace Core.Company
{
    public partial class CompanyType : BaseEntity
    {
        public int ID { get; set; }
        public string CompanyType1 { get; set; }
        public bool IsRemoved { get; set; }
    }
}
