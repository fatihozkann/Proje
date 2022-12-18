using Cheapla.Business.Services;
using Cheapla.WebUI.Models;
using Microsoft.AspNetCore.Mvc;
using X.PagedList;
using X.PagedList.Mvc;


namespace Cheapla.WebUI.ViewComponents
{
    public class ProductsViewComponent : ViewComponent
    {
        private readonly IProductService _productService;

        public ProductsViewComponent(IProductService productService)
        {
            _productService = productService;
        }

        public IViewComponentResult Invoke(int? categoryId = null, int page = 1)
        {
            if (page != null && page < 1)
            {
                page = 1;
            }

            var pageSize = 8;

            var products = _productService.GetProducts(categoryId);


            var viewModel = products.Select(x => new ProductViewModel
            {
                Id = x.Id,
                Name = x.Name,
                UnitPrice = x.UnitPrice,
                ImagePath = x.ImagePath,
                Description = x.Description,
                Summary = x.Summary
            });

            return View(viewModel.OrderBy(x => x.Id).ToPagedList(page, pageSize));
        }
    }
}
