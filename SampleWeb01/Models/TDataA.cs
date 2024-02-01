using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static SampleWeb01.Const.Const;

namespace SampleWeb01.Models
{
    [Table("t_data_a")]
    public class TDataA : BaseEntity
    {

        [Key]
        [Required]
        public int ID { get; set; }

        [Column("user_id")]
        [Required]
        public int userId { get; set; }

        [Column("data_cls")]
        [Required]
        public DataCls dataCls { get; set; }
        //TODO enumで定義するとint型になる
        //https://qiita.com/noobow/items/2083affa1c6f766e7a55

        [Column("status")]
        [Required]
        public Status status { get; set; }

        [Column("period_date")]
        [Required]
        public DateTime periodDate { get; set; }

        [Column("download_flg")]
        [Required]
        public bool downloadFlg { get; set; }

        [Column("deleted_flg")]
        [Required]
        public string? DeletedFlg { get; set; }

        public ICollection<TDataADetail> DataADetail { get; set; }

        public TUserCompany UserCompany { get; set; }
    }
}
