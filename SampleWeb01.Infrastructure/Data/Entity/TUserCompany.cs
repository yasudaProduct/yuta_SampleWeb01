using SampleWeb01.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SampleWeb01.Infrastructure.Data.Entity
{
    [Description("企業")]
    [Table("m_user_company")]
    public class TUserCompany : BaseEntity
    {
        [Description("ユーザーID")]
        [Key]
        [Column("user_id")]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int UserId { get; set; }

        [Description("企業名")]
        [Column("company_name")]
        [Required]
        [MaxLength(15)]
        public string CompanyName { get; set; }

        [Description("備考")]
        [Column("remarks")]
        [MaxLength(50)]
        public string? Remarks { get; set; }

        [Description("削除フラグ")]
        [Column("deleted_flg")]
        [Required]
        [DefaultValue("0")]
        [MaxLength(1)]
        public string? DeletedFlg { get; set; }

        public TUser User { get; set; }

    }
}
