using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class CategoryDto : BaseDto
    {
        public string Name { get; set; }
        public int ProductId { get; set; }
        public IEnumerable<ProductDto>? Products { get; set; }
    }
}
