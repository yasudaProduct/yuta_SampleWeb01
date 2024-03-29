﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SampleWeb01.Models
{
    [Table("t_user_company")]
    public class TUserCompany : BaseEntity
    {
        [Key]
        [Column("user_id")]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int UserId { get; set; }

        [Column("ccompany_name")]
        [Required]
        public string CompanyName { get; set; }

        [Column("remarks")]
        public string Remarks { get; set; }

        
        public TUser User { get; set; }

        public ICollection<TDataA> DataA { get; set; }

    }
}
