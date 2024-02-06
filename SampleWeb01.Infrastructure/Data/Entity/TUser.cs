using SampleWeb01.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SampleWeb01.Infrastructure.Data.Entity
{
    [Description("ユーザー")]
    [Table("m_user")]
    public class TUser : BaseEntity
    {
        [Description("ユーザーID")]
        [Key]
        [Column("user_id")]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int UserId { get; set; }

        [Description("パスワード")]
        [Column("password")]
        [Required]
        [MaxLength(12)]
        [MinLength(4)]
        public string Password { get; set; }

        [Description("メールアドレス")]
        [Column("mail_address")]
        [Required]
        [MaxLength(319)]
        public string MailAdress { get; set; }

        [Description("削除フラグ")]
        [Column("deleted_flg")]
        [Required]
        [DefaultValue("0")]
        [MaxLength(1)]
        public string? DeletedFlg { get; set; }


        public TUserCompany UserCompany { get; set; }

    }
}
