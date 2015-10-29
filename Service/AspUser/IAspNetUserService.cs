using Core.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.AspUser
{
    public partial interface IAspNetUserService
    {
        #region AspNetUser


        AspNetUser GetAspNetUserByUserName(string username);
        IList<AspNetUser> GetAllAspNetUser();
        IQueryable<AspNetUser> GetAllAspNetUserQueryable();        

        #endregion
    }
}
