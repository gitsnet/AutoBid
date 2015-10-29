using Core.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.User
{
    public partial interface IUserRoleService
    {
        #region Userrole

        void DeleteUserRole(UserRole userrole);
        void InsertUserRole(UserRole userrole);
        void UpdateUserRole(UserRole userrole);
        IList<UserRole> GetAllUserRole();
        IQueryable<UserRole> GetAllUserRoleQueryable();

        #endregion
    }
}
