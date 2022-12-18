using Cheapla.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cheapla.Data.Dto
{
    public class ProductListDto
    {
        public List<ProductDto> Products { get; set; }
        public ProductEntity Product { get; set; }
    }
}
