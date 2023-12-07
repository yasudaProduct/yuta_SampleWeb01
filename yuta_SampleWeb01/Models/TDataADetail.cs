using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace yuta_SampleWeb01.Models
{
    [Table("t_data_a_detail")]
    public class TDataADetail : BaseEntity
    {

        [Key]
        [Required]
        [Column("id")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }

        [Column("column1")]
        [Required]
        public string column1 { get; set; }

        [Column("column2")]
        [Required]
        public string column2 { get; set; }

        [Column("column3")]
        [Required]
        public string column3 { get; set; }

        [Column("column4")]
        [Required]
        public string column4 { get; set; }

        [Column("column5")]
        [Required]
        public string column5 { get; set; }

        public int DataId { get; set; }

        public TDataA DataA { get; set; }
    }
}
