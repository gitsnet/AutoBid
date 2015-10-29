using Core.Data;
using Core.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.AspUser
{
    public partial class AspNetUsersAdditionalInfoService : IAspNetUsersAdditionalInfoService
    {
        private readonly IRepository<AspNetUsersAdditionalInfo> _aspNetUsersAdditionalInfoRepository;

        public AspNetUsersAdditionalInfoService(IRepository<AspNetUsersAdditionalInfo> aspNetUsersAdditionalInfoRepository)
        {
            _aspNetUsersAdditionalInfoRepository = aspNetUsersAdditionalInfoRepository;
        }

        //public void Deleteuser(AspNetUsersAdditionalInfo user)
        //{
        //    if(user == null)
        //        throw new ArgumentNullException("user");
        //    user.IsDeleted = true;
        //    _userRepository.Update(user);
        //}

        //public Users GetUserById(long userId)
        //{
        //    if(userId == 0)
        //    {
        //        return null;
                
        //    }
        //    return _userRepository.GetById(userId);
        //}

        //public Users IsValidUser(string username,string password)
        //{
        //    Users user = GetAllUserQueryable().Where<Users>(u => u.Username == username && u.Password == password).FirstOrDefault();
        //    if (user == null)
        //        throw new ArgumentNullException("UserLogin");
            
        //        return user;
            
        //}

        //public IList<Users> GetAllUser()
        //{
        //    return _userRepository.Table.ToList<Users>();
        //}

        public void InsertAspNetUsersAdditionalInfo(AspNetUsersAdditionalInfo aspNetUsersAdditionalInfo)
        {
            if (aspNetUsersAdditionalInfo == null)
                throw new ArgumentNullException("AspNetUsersAdditionalInfo");
            _aspNetUsersAdditionalInfoRepository.Insert(aspNetUsersAdditionalInfo);
        }

        public void UpdateAspNetUsersAdditionalInfo(AspNetUsersAdditionalInfo aspNetUsersAdditionalInfo)
        {
            if (aspNetUsersAdditionalInfo == null)
                throw new ArgumentNullException("AspNetUsersAdditionalInfo");
            _aspNetUsersAdditionalInfoRepository.Update(aspNetUsersAdditionalInfo);
        }

        //public IQueryable<Users> GetAllUserQueryable()
        //{
        //    return _userRepository.Table;
        //}

        //public bool CheckDuplicateUserName(string username, string password)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
