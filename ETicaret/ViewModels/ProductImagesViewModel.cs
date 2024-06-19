using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels
{
    public class ProductImagesViewModel : BaseViewModel
    {
        public string ImageName { get; set; }
        public int ProductId { get; set; }

        [ForeignKey("ProductId")]
        public ProductViewModel Product { get; set; }
    }
}
