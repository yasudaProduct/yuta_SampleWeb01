using Humanizer;
using Merino.Service;
using Microsoft.EntityFrameworkCore;
using yuta_SampleWeb01.Data;
using yuta_SampleWeb01.Models;
using yuta_SampleWeb01.Services.Dao;
using yuta_SampleWeb01.ViewModels;

namespace yuta_SampleWeb01.Services.Businesses
{
    public class UserBusiness
    {

        private readonly IUserDao _userDao;

        public UserBusiness(IUserDao userDao)
        {
            _userDao = userDao;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userModel"></param>
        /// <returns></returns>
        public bool CreateUser(UserViewModel userModel)
        {

            TUser user = new TUser(){
                UserId = userModel.UserId,
                Password = userModel.Password,
                DeletedFlg = "0",
                CreateDate = new DateTime(),
                CreateUserId = "test",
                CreatePgmId = "test",
                UpdateDate = new DateTime(),
                UpdateUserId = "test",
                UpdatePgmId = "test"
            };

            TUserCompany userCompany = new TUserCompany()
            {
                UserId = userModel.UserId,
                CompanyName = userModel.CompanyName,
                Remarks = userModel.Remarks,
                CreateDate = new DateTime(),
                CreateUserId = "test",
                CreatePgmId = "test",
                UpdateDate = new DateTime(),
                UpdateUserId = "test",
                UpdatePgmId = "test"
            };

            _userDao.create(user, userCompany);

            return true;
        }

    }
}
