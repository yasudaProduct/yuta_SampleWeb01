using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace yuta_SampleWeb01.Entity
{
    [Table("t_user_company")]
    public class TUserCompany
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

        [Column("deleted_flg")]
        [Required]
        public string? DeletedFlg { get; set; }

        [Column("create_pgm_id")]
        [Required]
        public string? CreatePgmId { get; set; }

        [Column("create_user_id")]
        [Required]
        public string? CreateUserId { get; set; }

        [Column("create_date")]
        [Required]
        public DateTime CreateDate { get; set; }

        [Column("update_pgm_id")]
        [Required]
        public string? UpdatePgmId { get; set; }

        [Column("update_user_id")]
        [Required]
        public string? UpdateUserId { get; set; }

        [Column("update_date")]
        [Required]
        public DateTime UpdateDate { get; set; }

    }
}
