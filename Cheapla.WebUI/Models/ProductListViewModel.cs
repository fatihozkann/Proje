using Cheapla.Data.Dto;
using Cheapla.Data.Entities;

namespace Cheapla.WebUI.Models
{
    public class ProductListViewModel
    {
        public List<ProductDto> Products { get; set; }
        public ProductListDto? Product { get; set; }
    }
}
