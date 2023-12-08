using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using yuta_SampleWeb01.Models;
using static yuta_SampleWeb01.Models.TDataA;

namespace yuta_SampleWeb01.ViewModels
{
    public class DataListViewModel
    {

        public List<TDataA> DataA { get; set; }

        //public string? UserIdCond { get; set; }

        //public string? CompanyNameCond { get; set; }

        public SearchCond SearchCondition;

        public class SearchCond
        {

            public string? UserIdCond { get; set; }

            public string? CompanyNameCond { get; set; }
        }

        //[Required]
        //public int DataId { get; set; }

        //[Required]
        //public string CompanyUserId { get; set; }

        //[Required]
        //public string CompanyName { get; set; }

        //[Required]
        //public Status Status { get; set; }

        //[Required]
        //public DataCls DataCls { get; set; }

        //[Required]
        //public DateTime PeriodDate { get; set; }

        //[Required]
        //public bool DownloadFlg { get; set; }

    }
}
