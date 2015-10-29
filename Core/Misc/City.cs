using System;
using System.Collections.Generic;

namespace Core.Misc
{
    public partial class City : BaseEntity
    {
        public int ID { get; set; }
        public string CityName { get; set; }
        public Nullable<int> CountryID { get; set; }
    }
}
