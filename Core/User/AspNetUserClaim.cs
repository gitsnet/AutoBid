using System;
using System.Collections.Generic;

namespace Core.User
{
    public partial class AspNetUserClaim : BaseEntity
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string ClaimType { get; set; }
        public string ClaimValue { get; set; }
        public virtual AspNetUser AspNetUser { get; set; }
    }
}
