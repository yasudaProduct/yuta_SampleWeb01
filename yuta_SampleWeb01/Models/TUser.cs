using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace yuta_SampleWeb01.Models
{
    [Table("t_user")]
    public class TUser : BaseEntity
    {
        [Key]
        [Column("user_id")]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int UserId { get; set; }

        [Column("password")]
        [Required]
        public string Password { get; set; }

    }
}
