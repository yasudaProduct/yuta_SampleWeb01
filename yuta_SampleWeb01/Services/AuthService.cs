using Humanizer;
using Merino.Service;
using Microsoft.EntityFrameworkCore;
using yuta_SampleWeb01.Data;
using yuta_SampleWeb01.Models;
using yuta_SampleWeb01.ViewModels;
using yuta_SampleWeb01.Services.Dao;
using yuta_SampleWeb01.Services.Businesses;
using yuta_SampleWeb01.Controllers;
using static yuta_SampleWeb01.Models.TDataA;
using static yuta_SampleWeb01.Const.Const;
using System.Linq;

namespace yuta_SampleWeb01.Services
{

    public interface IAuthService
    {
        /// <summary>
        /// DataAリスト取得
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
        private readonly yuta_SampleWeb01Context _context;

        //private readonly UserBusiness  _userBusiness;

        public AuthService(yuta_SampleWeb01Context context) 
        {
            _context = context;
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
            using (var tran = _context.Database.BeginTransaction())
            {

                //データ取得
                dataList = _context.TUser
                    .Where(u => u.DeletedFlg == "0" && u.UserId == int.Parse(userId) && u.Password == password)
                    .ToList();
            };
            
            return dataList.FirstOrDefault();
        }
        
    }
}
