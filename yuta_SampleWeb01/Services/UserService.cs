using Humanizer;
using Merino.Service;
using Microsoft.EntityFrameworkCore;
using yuta_SampleWeb01.Data;
using yuta_SampleWeb01.Entity;
using yuta_SampleWeb01.Models;
using yuta_SampleWeb01.Services.Dao;

namespace yuta_SampleWeb01.Services
{
    public class UserService: MerinoService
    {
        private readonly yuta_SampleWeb01Context _context;

        private readonly UserDao _userDao;

        public UserService(yuta_SampleWeb01Context context, UserDao userDao) 
        {
            _context = context;
            _userDao = userDao;
        }

        public UserViewModel create(UserViewModel user) {

            //トランザクション
            using (var tran = _context.Database.BeginTransaction())
            {

                TUserCompany userCompany = new TUserCompany();
                userCompany.UserId = user.UserId;
                userCompany.CompanyName = user.CompanyName;
                userCompany.Remarks = user.Remarks;
                userCompany.DeletedFlg = "";
                userCompany.CreateDate = new DateTime();
                userCompany.CreateUserId = "test";
                userCompany.CreatePgmId = "test";
                userCompany.UpdateDate = new DateTime();
                userCompany.UpdateUserId = "test";
                userCompany.UpdatePgmId = "test";

                _userDao.Create(userCompany);
                
            };

            return null;
        }
    }
}
