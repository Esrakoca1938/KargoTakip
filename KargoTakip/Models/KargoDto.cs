using KargoTakip.Core.Enum;

namespace KargoTakip.WebUI.Models
{
    public class KargoDto : BaseDto
    {
        public string TakipNo { get; set; }
        public int GonderenMusteriId { get; set; }
        public int AliciMusteriId { get; set; }
        public int GonderenSubeId { get; set; }
        public int AliciSubeId { get; set; }
        public int TeslimAlanPersonelId { get; set; }
        public int? TeslimEdenPersonelId { get; set; }
        public int UcretId { get; set; }
        public OdemeTuru? OdemeTuru { get; set; }

        public DateTime? TahminiTeslimTarihi { get; set; }
        public DateTime? TeslimTarihi { get; set; }
        public KargoDurum? Durum { get; set; }

        public virtual PersonelDto? TeslimAlanPersonel { get; set; }
        public virtual PersonelDto? TeslimEdenPersonel { get; set; }
        public virtual UcretDto? Ucret { get; set; }
        public virtual MusteriDto? AliciMusteri { get; set; }
        public virtual SubeDto? AliciSube { get; set; }
        public virtual MusteriDto? GonderenMusteri { get; set; }
        public virtual SubeDto? GonderenSube { get; set; }
        public virtual ICollection<KargoDetayDto>? KargoDetaylari { get; set; }
    }
}
