using Merino.Service;
using SampleWeb01.ViewModels;
using System.Transactions;

namespace SampleWeb01.Services
{

    public interface IUserService
    {
        public UserViewModel create(UserViewModel userModel);
    }

    public class UserService : MerinoService , IUserService
    {
        //private readonly SampleWeb01Context _context;

        //private readonly UserBusiness  _userBusiness;

        public UserService () 
        {
            //_context = context;
            //_userBusiness = userBusiness;
        }

        /// <summary>
        /// ユーザーを登録する
        /// </summary>
        /// <param name="userModel"></param>
        /// <returns></returns>
        public UserViewModel create(UserViewModel userModel) {

            //トランザクション
            using (var tran = new TransactionScope())
            {

                //ユーザー登録
                //_userBusiness.CreateUser(userModel);

                //tran.Commit();

            };

            return null;
        }
    }
}
