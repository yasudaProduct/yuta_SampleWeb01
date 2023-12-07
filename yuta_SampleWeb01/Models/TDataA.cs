using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace yuta_SampleWeb01.Models
{
    [Table("t_data_a")]
    public class TDataA : BaseEntity
    {

        public enum dataCle
        {
            DataA = 1,
            DataB = 2,
            DataC = 3,
        }

        public enum Status
        {
            Registration = 1,
            Entry = 2,
            completion = 3,
        }

        [Key]
        [Required]
        public int ID { get; set; }

        [Column("user_id")]
        [Required]
        public string userId { get; set; }

        [Column("data_cls")]
        [Required]
        public dataCle dataCls { get; set; }

        [Column("status")]
        [Required]
        public dataCle status { get; set; }

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
    }
}
