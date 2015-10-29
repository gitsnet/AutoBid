using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Data;
using Core.User;

namespace Service.AspUser
{
    public partial class AspNetRolesService : IAspNetRolesService
    {
        private readonly IRepository<AspNetRole> _aspNetRoleRepository;

        public AspNetRolesService(IRepository<AspNetRole> aspNetRoleRepository)
        {
            _aspNetRoleRepository = aspNetRoleRepository;
        }
        public IQueryable<AspNetRole> GetAllAspNetRoleQueryable()
        {
            return _aspNetRoleRepository.Table;
        }
        public IList<AspNetRole> GetAllAspNetRoles()
        {
            return _aspNetRoleRepository.Table.ToList<AspNetRole>();
        }
        public AspNetRole GetAspNetRoleByRoleID(string roleID)
        {
            return _aspNetRoleRepository.Table.Where(c => c.Id == roleID).FirstOrDefault<AspNetRole>();
        }
    }
}
