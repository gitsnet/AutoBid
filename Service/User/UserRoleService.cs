using Core.Data;
using Core.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.User
{
    public partial class UserRoleService : IUserRoleService
    {
        private readonly IRepository<UserRole> _userroleRepository;

        public UserRoleService(IRepository<UserRole> userroleRepository)
        {
            _userroleRepository = userroleRepository;
        }

        public void DeleteUserRole(UserRole userrole)
        {
            if(userrole == null)
                throw new ArgumentNullException("userrole");
            userrole.IsDeleted = true;
            _userroleRepository.Update(userrole);
        }

        public void InsertUserRole(UserRole userrole)
        {
            if(userrole==null)
                throw new ArgumentNullException("userrole");
            _userroleRepository.Insert(userrole);
        }

        public void UpdateUserRole(UserRole userrole)
        {
            if(userrole == null)
                throw new ArgumentNullException("userrole");
            _userroleRepository.Update(userrole);
        }

        public IList<UserRole> GetAllUserRole()
        {
            return _userroleRepository.Table.ToList<UserRole>();
        }

        public IQueryable<UserRole> GetAllUserRoleQueryable()
        {
            return _userroleRepository.Table;
        }
    }
}
