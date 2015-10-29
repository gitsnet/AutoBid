using System;
using System.Collections.Generic;

namespace Core.Misc
{
    public partial class Country : BaseEntity
    {
        public int ID { get; set; }
        public string CountryName { get; set; }
        public string DisplayName { get; set; }
        public string FormalName { get; set; }
        public string Type { get; set; }
        public string SubType { get; set; }
        public string Sovereignty { get; set; }
        public string Capital { get; set; }
        public string ISO_4217_Currency_Code { get; set; }
        public string ISO_4217_Currency_Name { get; set; }
        public string ITU_T_Telephone_Code { get; set; }
        public string ISO_3166_1_2Letter_Code { get; set; }
        public string ISO_3166_1_3Letter_Code { get; set; }
        public string ISO_3166_1Number { get; set; }
        public string IANA_Country_Code_TLD { get; set; }
        public Nullable<bool> IsListed { get; set; }
    }
}
