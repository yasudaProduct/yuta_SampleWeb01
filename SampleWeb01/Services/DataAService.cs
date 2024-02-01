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

    public interface IDataAService
    {
        /// <summary>
        /// DataAリスト取得
        /// </summary>
        /// <returns></returns>
        public List<TDataA> getDataList();

        /// <summary>
        /// DataA検索
        /// </summary>
        /// <returns></returns>
        public List<TDataA> searchDataList(string cond);
    }

    public class DataAService : MerinoService , IDataAService
    {
        private readonly SampleWeb01Context _context;

        //private readonly UserBusiness  _userBusiness;

        public DataAService(SampleWeb01Context context) 
        {
            _context = context;
        }

        /// <summary>
        /// 
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

        public List<TDataA> searchDataList(string cond)
        {

            List<TDataA> dataList = null;

            //トランザクション
            using (var tran = _context.Database.BeginTransaction())
            {

                //データ取得
                dataList = _context.TDataA
                    .Include(d => d.UserCompany)
                    .Where(c =>
                    c.DeletedFlg == "0"
                    && c.status != Status.completion
                    && c.UserCompany.CompanyName == cond)
                    .ToList<TDataA>();
            };

            return dataList;
        }
        
    }
}
