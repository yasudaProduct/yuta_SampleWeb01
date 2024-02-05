using Merino.Service;
using SampleWeb01.Models;
using System.Transactions;

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
        //private readonly SampleWeb01Context _context;

        //private readonly UserBusiness  _userBusiness;

        public DataAService() 
        {
            //_context = context;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userModel"></param>
        /// <returns></returns>
        public List<TDataA> getDataList() {

            List<TDataA> dataList = null;

            //トランザクション
            using (var tran = new TransactionScope())
            {

                //データ取得
                //dataList = _context.TDataA
                //    .Include(d => d.UserCompany)
                //    .Where(c => c.DeletedFlg == "0" && c.status != Status.completion)
                //    .ToList<TDataA>();

            };

            return dataList;
        }

        public List<TDataA> searchDataList(string cond)
        {

            List<TDataA> dataList = null;

            //トランザクション
            using (var tran = new TransactionScope())
            {

                //データ取得
                //dataList = _context.TDataA
                //    .Include(d => d.UserCompany)
                //    .Where(c =>
                //    c.DeletedFlg == "0"
                //    && c.status != Status.completion
                //    && c.UserCompany.CompanyName == cond)
                //    .ToList<TDataA>();
            };

            return dataList;
        }
        
    }
}
