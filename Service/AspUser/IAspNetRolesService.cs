using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.User;

namespace Service.AspUser
{
    public partial interface IAspNetRolesService
    {

        AspNetRole GetAspNetRoleByRoleID(string roleID);
        IList<AspNetRole> GetAllAspNetRoles();
        IQueryable<AspNetRole> GetAllAspNetRoleQueryable();  
    }
}
