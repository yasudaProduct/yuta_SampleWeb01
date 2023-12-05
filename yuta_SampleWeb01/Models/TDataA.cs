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

        [Key]
        [Required]
        public int ID { get; set; }

        [Column("user_id")]
        [Required]
        public string userId { get; set; }

        [Column("data_cls")]
        public dataCle dataCls { get; set; }

    }
}
