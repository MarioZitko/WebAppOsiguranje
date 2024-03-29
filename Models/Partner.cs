﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebAppOsiguranje.Models
{
    public class Partner
    {
        [Key]
        public int PartnerId { get; set; }

        [Required]
        [StringLength(255, MinimumLength = 2)]
        [Display(Name = "Ime partnera")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(255, MinimumLength = 2)]
        [Display(Name = "Prezime partnera")]
        public string LastName { get; set; }

        [Display(Name = "Adresa")]
        public string Address { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 20)]
        [Display(Name = "Šifra partnera")]
        public string PartnerNumber { get; set; }

        [StringLength(11)]
        [Display(Name = "OIB")]
        public string CroatianPIN { get; set; }

        [Required]
        [Display(Name = "Vrsta partnera")]
        public int PartnerTypeId { get; set; } // 1 for Personal, 2 for Legal

        [Required]
        public DateTime CreatedAtUtc { get; set; } = DateTime.UtcNow;

        [Required]
        [EmailAddress]
        [StringLength(255)]
        [Display(Name = "Kreiran od korisnika")]
        public string CreateByUser { get; set; }

        [Required]
        [Display(Name = "Stranac")]
        public bool IsForeign { get; set; }

        [StringLength(20, MinimumLength = 10)]
        public string ExternalCode { get; set; }

        [Required]
        [Display(Name = "Spol")]
        public char Gender { get; set; } // M, F, or N

        public bool IsHighlighted { get; set; }
    }
}
