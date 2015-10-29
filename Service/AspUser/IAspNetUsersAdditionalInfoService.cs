using Core.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.AspUser
{
    public partial interface IAspNetUsersAdditionalInfoService
    {
        #region AspNetUsersAdditionalInfo

        //void DeleteAspNetUsersAdditionalInfo(AspNetUsersAdditionalInfo aspNetUsersAdditionalInfo);
        //AspNetUsersAdditionalInfo GetAspNetUsersAdditionalInfoById(long AspNetUsersAdditionalInfoID);
        //IList<AspNetUsersAdditionalInfo> GetAllUser();
        void InsertAspNetUsersAdditionalInfo(AspNetUsersAdditionalInfo aspNetUsersAdditionalInfo);
        void UpdateAspNetUsersAdditionalInfo(AspNetUsersAdditionalInfo aspNetUsersAdditionalInfo);
        //IQueryable<Users> GetAllUserQueryable();
        //Users IsValidUser(string username, string password);

        #endregion
    }
}
