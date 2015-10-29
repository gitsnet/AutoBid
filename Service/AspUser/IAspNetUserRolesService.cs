using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.User;

namespace Service.AspUser
{
   public partial interface IAspNetUserRolesService
    {
        IQueryable<AspNetUserRoles> GetAllAspNetUserRolesQueryable();
        AspNetUserRoles InsertAspNetUserRole(AspNetUserRoles aspNetUserRole);
    }
}
