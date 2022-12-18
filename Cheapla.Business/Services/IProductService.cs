using Cheapla.Business.Types;
using Cheapla.Data.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cheapla.Business.Services
{
    public interface IProductService
    {
        ServiceMessage AddProduct(ProductDto product);

        ProductListDto GetAllProduct(int? categoryId = null);

        ProductDto GetProductById(int id);

         List<ProductDto> GetProducts(int? categoryId = null);
        void EditProduct(ProductDto product);

        void DeleteProduct(int id);
    }
}
