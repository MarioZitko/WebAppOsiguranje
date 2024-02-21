using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebAppOsiguranje.Models;

namespace WebAppOsiguranje.Models
{
    public class Policy
    {
        [Key]
        public int PolicyId { get; set; }

        [Required]
        [StringLength(15, MinimumLength = 10)]
        [Display(Name = "Broj police")]
        public string PolicyNumber { get; set; }

        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        [Display(Name = "Iznos police")]
        public decimal Amount { get; set; }

        // Foreign key
        public int PartnerId { get; set; }

        // Navigation property
        public Partner Partner { get; set; }
    }
}
