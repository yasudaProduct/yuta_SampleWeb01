using Merino.Service;
using SampleWeb01.Models;
using System.Transactions;

namespace SampleWeb01.Services
{

    public interface IAuthService
    {
        /// <summary>
        /// 認証
        /// </summary>
        /// <returns></returns>
        public TUser Auth(string user_id, string password);

        /// <summary>
        /// DataA検索
        /// </summary>
        /// <returns></returns>
        //public List<TDataA> searchDataList(string cond);
    }

    public class AuthService : MerinoService , IAuthService
    {
        //private readonly SampleWeb01Context _context;

        //private readonly UserBusiness  _userBusiness;

        public AuthService() 
        {
            //_context = context;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public TUser Auth(string userId, string password) {

            List<TUser> dataList = null;

            //トランザクション
            using (var tran = new TransactionScope())
            {

                try { 
                //データ取得
                //dataList = _context.TUser
                //    .Where(u => u.DeletedFlg == "0" && u.UserId == int.Parse(userId) && u.Password == password)
                //    .ToList();
                }
                catch(Exception ex)
                {
                    
                }
            };
            
            return dataList.FirstOrDefault();
        }
        
    }
}
