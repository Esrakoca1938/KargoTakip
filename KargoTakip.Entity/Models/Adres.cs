using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using KargoTakip.Entity.Models;

namespace KargoTakip.Entity.Models
{
    [Table("Adres")]
    public partial class Adres : AuditableEntity
    {
        public Adres()
        {
            Subeler = new HashSet<Sube>();
            Musteriler = new HashSet<Musteri>();
        }

        [Required]
        [MaxLength(50)]
        public string AdresAdi { get; set; }

        [Required]
        public int SehirId { get; set; }

        public int? IlceId { get; set; }

        [Required]
        [MaxLength(250)]
        public string Detay { get; set; }


        [MaxLength(5)]
        public string PostaKodu { get; set; }


        [MaxLength(11)]
        public string Telefon { get; set; }

        [MaxLength(100)]
        public string Email { get; set; }

        public virtual Sehir? Sehir { get; set; }
        public virtual Ilce? Ilce { get; set; }
        public virtual ICollection<Sube>? Subeler { get; set; }
        public virtual ICollection<Musteri>? Musteriler { get; set; }
    }
}
