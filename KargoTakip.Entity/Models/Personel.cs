using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using KargoTakip.Entity.Models;

namespace KargoTakip.Entity.Models
{
    [Table("Personel")]
    public partial class Personel : AuditableEntity
    {
        public Personel()
        {
            TeslimAlinanKargolar = new HashSet<Kargo>();
            TeslimEdilenKargolar = new HashSet<Kargo>();
        }

        [Required]
        [MaxLength(50)]
        public string Adi { get; set; }
        [Required]
        [MaxLength(50)]
        public string Soyadi { get; set; }

        [MaxLength(11)]
        public string? KimlikNo { get; set; }

        [MaxLength(10)]
        public string? Cinsiyet { get; set; }

        [MaxLength(100)]
        [Required]
        public string Email { get; set; }

        [MaxLength(100)]
        [Required]
        public string Sifre { get; set; }

        [MaxLength(50)]
       
        public string? Pozisyon { get; set; }

        [NotMapped]
        public string AdSoyad => Adi + " " + Soyadi;

        public virtual ICollection<Kargo>? TeslimAlinanKargolar { get; set; }
        public virtual ICollection<Kargo>? TeslimEdilenKargolar { get; set; }
    }
}
