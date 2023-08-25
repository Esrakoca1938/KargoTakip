using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using KargoTakip.Core.Enum;
using KargoTakip.Entity.Models;

namespace KargoTakip.Entity.Models
{
    [Table("Kargo")]
    public partial class Kargo : AuditableEntity
    {
        public Kargo()
        {
            KargoDetaylari = new HashSet<KargoDetay>();
        }

        [MaxLength(20)]
        [Required]
        public string TakipNo { get; set; }

        [Required]
        public int GonderenMusteriId { get; set; }
        [Required]
        public int AliciMusteriId { get; set; }
        [Required]
        public int GonderenSubeId { get; set; }
        [Required]
        public int AliciSubeId { get; set; }
        [Required]
        public int TeslimAlanPersonelId { get; set; }
        public int? TeslimEdenPersonelId { get; set; }
        [Required]
        public int UcretId { get; set; }
        [Required]
        public OdemeTuru OdemeTuru { get; set; }

        public DateTime? TahminiTeslimTarihi { get; set; }
        public DateTime? TeslimTarihi { get; set; }

        [Required]
        public KargoDurum Durum { get; set; }

        public virtual Personel TeslimAlanPersonel { get; set; }
        public virtual Personel TeslimEdenPersonel { get; set; }
        public virtual Ucret Ucret { get; set; }
        public virtual Musteri AliciMusteri { get; set; }
        public virtual Sube AliciSube { get; set; }
        public virtual Musteri GonderenMusteri { get; set; }
        public virtual Sube GonderenSube { get; set; }
        public virtual ICollection<KargoDetay>? KargoDetaylari { get; set; }
    }
}
