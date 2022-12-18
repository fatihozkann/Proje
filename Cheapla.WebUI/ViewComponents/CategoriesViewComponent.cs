using Cheapla.Business.Services;
using Cheapla.WebUI.Models;
using Microsoft.AspNetCore.Mvc;

namespace Cheapla.WebUI.ViewComponents
{
    public class CategoriesViewComponent : ViewComponent
    {

        private readonly ICategoryService _categoryService;

        public CategoriesViewComponent(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public IViewComponentResult Invoke()
        {
            var categories = _categoryService.GetCategories();

            var viewModel = categories.Select(x => new CategoryViewModel
            {
                Id = x.Id,
                Name = x.Name,
            }).ToList();

            return View(viewModel);
        }
    }
}
