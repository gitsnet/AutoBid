using System;
using System.Collections.Generic;

namespace Core.User
{
    public partial class UserType : BaseEntity
    {
        public UserType()
        {
            this.AspNetUsersANDUserTypesMappings = new List<AspNetUsersANDUserTypesMapping>();
        }

        public int ID { get; set; }
        public string UserType1 { get; set; }
        public bool IsRemoved { get; set; }
        public virtual ICollection<AspNetUsersANDUserTypesMapping> AspNetUsersANDUserTypesMappings { get; set; }
    }
}
