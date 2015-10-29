using System;
using System.Collections.Generic;

namespace Core.User
{
    public partial class AspNetUsersANDUserTypesMapping : BaseEntity
    {
        public int ID { get; set; }
        public int UserID { get; set; }
        public int UserTypeID { get; set; }
        public virtual AspNetUsersAdditionalInfo AspNetUsersAdditionalInfo { get; set; }
        public virtual UserType UserType { get; set; }
    }
}
