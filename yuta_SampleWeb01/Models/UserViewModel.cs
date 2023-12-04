using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace yuta_SampleWeb01.Models
{
    public class UserViewModel
    {
        public int UserId { get; set; }

        [StringLength(10, MinimumLength = 3)]
        [Required]
        public string? CompanyName { get; set; }

        [StringLength(20, MinimumLength = 3)]
        [Required]
        public string? Remarks { get; set; }
    }
}
