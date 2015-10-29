using System;
using System.Collections.Generic;

namespace Core.User
{
    public partial class UserProfile : BaseEntity
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
    }
}
