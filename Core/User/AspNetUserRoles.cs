using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.User
{
    public partial class AspNetUserRoles : BaseEntity
    {
        [Key]
        public string UserId { get; set; }
        public string RoleId { get; set; }
    }
}
