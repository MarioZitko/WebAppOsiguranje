using System;
using System.ComponentModel.DataAnnotations;

namespace WebAppOsiguranje.Models
{
    public class Partner
    {
        [Key]
        public int PartnerId { get; set; }

        [Required]
        [StringLength(255, MinimumLength = 2)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(255, MinimumLength = 2)]
        public string LastName { get; set; }

        public string Address { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 20)]
        public string PartnerNumber { get; set; }

        [StringLength(11)]
        public string CroatianPIN { get; set; }

        [Required]
        public int PartnerTypeId { get; set; } // 1 for Personal, 2 for Legal

        [Required]
        public DateTime CreatedAtUtc { get; set; } = DateTime.UtcNow;

        [Required]
        [EmailAddress]
        [StringLength(255)]
        public string CreateByUser { get; set; }

        [Required]
        public bool IsForeign { get; set; }

        [StringLength(20, MinimumLength = 10)]
        public string ExternalCode { get; set; }

        [Required]
        public char Gender { get; set; } // M, F, or N
    }
}
