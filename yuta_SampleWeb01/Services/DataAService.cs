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

    public interface IDataAService
    {
        /// <summary>
        /// DataAリスト取得
        /// </summary>
        /// <returns></returns>
        public List<TDataA> getDataList();
    }

    public class DataAService : MerinoService , IDataAService
    {
        private readonly yuta_SampleWeb01Context _context;

        //private readonly UserBusiness  _userBusiness;

        public DataAService(yuta_SampleWeb01Context context) 
        {
            _context = context;
        }

        /// <summary>
        /// ユーザーを登録する
        /// </summary>
        /// <param name="userModel"></param>
        /// <returns></returns>
        public List<TDataA> getDataList() {

            List<TDataA> dataList = null;

            //トランザクション
            using (var tran = _context.Database.BeginTransaction())
            {

                //データ取得
                dataList = _context.TDataA
                    .Include(d => d.UserCompany)
                    .Where(c => c.DeletedFlg == "0" && c.status != Status.completion)
                    .ToList<TDataA>();

            };

            return dataList;
        }
    }
}
