using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Data;
using Core.User;

namespace Service.AspUser
{
    public partial class AspNetUserRolesService : IAspNetUserRolesService
    {
        private readonly IRepository<AspNetUserRoles> _aspNetUserRoleRepository;

        public AspNetUserRolesService(IRepository<AspNetUserRoles> aspNetUserRoleRepository)
        {
            _aspNetUserRoleRepository = aspNetUserRoleRepository;
        }
        public IQueryable<AspNetUserRoles> GetAllAspNetUserRolesQueryable()
        {
            return _aspNetUserRoleRepository.Table;
        }
        public AspNetUserRoles InsertAspNetUserRole(AspNetUserRoles aspNetUserRole)
        {
            if (aspNetUserRole == null)
                return null;
            else
            {
                _aspNetUserRoleRepository.Insert(aspNetUserRole);
                return aspNetUserRole;
            }
        }
    }
}
