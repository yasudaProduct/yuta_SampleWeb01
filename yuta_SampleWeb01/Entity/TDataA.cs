using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace yuta_SampleWeb01.Entity
{
    [Table("t_data_a")]
    public class TDataA : BaseEntity
    {
        [Key]
        [Column("user_id")]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int UserId { get; set; }

        [Column("ccompany_name")]
        public string? CompanyName { get; set; }

        [Column("remarks")]
        public string? Remarks { get; set; }

    }
}
