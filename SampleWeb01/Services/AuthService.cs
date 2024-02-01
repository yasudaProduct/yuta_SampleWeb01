using Humanizer;
using Merino.Service;
using Microsoft.EntityFrameworkCore;
using SampleWeb01.Data;
using SampleWeb01.Models;
using SampleWeb01.ViewModels;
using SampleWeb01.Services.Dao;
using SampleWeb01.Services.Businesses;
using SampleWeb01.Controllers;
using static SampleWeb01.Models.TDataA;
using static SampleWeb01.Const.Const;
using System.Linq;

namespace SampleWeb01.Services
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
        private readonly SampleWeb01Context _context;

        //private readonly UserBusiness  _userBusiness;

        public AuthService(SampleWeb01Context context) 
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

                try { 
                //データ取得
                dataList = _context.TUser
                    .Where(u => u.DeletedFlg == "0" && u.UserId == int.Parse(userId) && u.Password == password)
                    .ToList();
                }
                catch(Exception ex)
                {
                    
                }
            };
            
            return dataList.FirstOrDefault();
        }
        
    }
}
