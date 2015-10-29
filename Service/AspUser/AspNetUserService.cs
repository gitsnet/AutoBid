using Core.Data;
using Core.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.AspUser
{
    public partial class AspNetUserService : IAspNetUserService
    {
        private readonly IRepository<AspNetUser> _aspNetUserRepository;

        public AspNetUserService(IRepository<AspNetUser> aspNetUserRepository)
        {
            _aspNetUserRepository = aspNetUserRepository;
        }
        public AspNetUser GetAspNetUserByUserName(string username)
        {
            return _aspNetUserRepository.Table.Where<AspNetUser>(au=>au.UserName==username).FirstOrDefault<AspNetUser>();
        }
        public IList<AspNetUser> GetAllAspNetUser()
        {
            return _aspNetUserRepository.Table.ToList<AspNetUser>();
        }
        public IQueryable<AspNetUser> GetAllAspNetUserQueryable()
        {
            return _aspNetUserRepository.Table;
        }

    }
}
