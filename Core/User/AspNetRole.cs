using System;
using System.Collections.Generic;

namespace Core.User
{
    public partial class AspNetRole : BaseEntity
    {
        public AspNetRole()
        {
            this.AspNetUsers = new List<AspNetUser>();
            this.AspNetUserRoles = new List<AspNetUserRoles>();
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<AspNetUser> AspNetUsers { get; set; }

        public virtual ICollection<AspNetUserRoles> AspNetUserRoles { get; set; }
    }
}
