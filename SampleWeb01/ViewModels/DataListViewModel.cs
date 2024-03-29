﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SampleWeb01.Models;
using static SampleWeb01.Models.TDataA;

namespace SampleWeb01.ViewModels
{
    public class DataListViewModel
    {

        public List<TDataA> DataA { get; set; }

        //public string? UserIdCond { get; set; }

        //public string? CompanyNameCond { get; set; }

        public SearchCond SearchCondition { get; set; }

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
