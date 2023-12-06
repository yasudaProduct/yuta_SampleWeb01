using Humanizer;
using Merino.Service;
using Microsoft.EntityFrameworkCore;
using yuta_SampleWeb01.Data;
using yuta_SampleWeb01.Models;
using yuta_SampleWeb01.ViewModels;
using yuta_SampleWeb01.Services.Dao;
using yuta_SampleWeb01.Services.Businesses;

namespace yuta_SampleWeb01.Services
{

    public interface IUserService
    {
        public UserViewModel create(UserViewModel userModel);
    }

    public class UserService : MerinoService , IUserService
    {
        private readonly yuta_SampleWeb01Context _context;

        private readonly UserBusiness  _userBusiness;

        public UserService (yuta_SampleWeb01Context context, UserBusiness userBusiness) 
        {
            _context = context;
            _userBusiness = userBusiness;
        }

        /// <summary>
        /// ユーザーを登録する
        /// </summary>
        /// <param name="userModel"></param>
        /// <returns></returns>
        public UserViewModel create(UserViewModel userModel) {

            //トランザクション
            using (var tran = _context.Database.BeginTransaction())
            {

                //ユーザー登録
                _userBusiness.CreateUser(userModel);

                tran.Commit();

            };

            return null;
        }
    }
}
