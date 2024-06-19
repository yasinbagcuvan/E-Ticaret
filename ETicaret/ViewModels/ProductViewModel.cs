using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels
{
    public class ProductViewModel : BaseViewModel
    {
        public int CategoryId { get; set; }
        public CategoryViewModel Category { get; set; }
        public string Model { get; set; }
        public string İlanBasligi { get; set; }
        public int Kilometre { get; set; }
        public int CikisYili { get; set; }
        public decimal Fiyat { get; set; }
        public short MotorHacmi { get; set; }
        public short MotorGücü { get; set; }
        public ICollection<ProductImagesViewModel> ProductImages { get; set; }
        public Sehir Sehir { get; set; }
        public Yakit Yakit { get; set; }
        public Vites Vites { get; set; }
        public AracDurumu AracDurumu { get; set; }
        public KasaTipi KasaTipi { get; set; }
        public Cekis Cekis { get; set; }
        public Renk Renk { get; set; }
        public Garanti Garanti { get; set; }
        public AgirHasarKayitli AgirHasarKayitli { get; set; }
        public PlakaUyruk PlakaUyruk { get; set; }
        public Kimden Kimden { get; set; }
        public Takasli Takasli { get; set; }
        public Boyali Boyali { get; set; }
        public Degisen Degisen { get; set; }
    }
}
