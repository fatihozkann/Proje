using Cheapla.Business.Services;
using Cheapla.Data.Dto;
using Cheapla.WebUI.Areas.Admin.Models;
using Microsoft.AspNetCore.Mvc;

namespace Cheapla.WebUI.Areas.Admin.Controllers
{
   
        public class CategoryController : BaseController
        {
            private readonly ICategoryService _categoryService;


            public CategoryController(ICategoryService categoryService)
            {
                _categoryService = categoryService;
            }
            public IActionResult Index()
            {
                var categoryList = _categoryService.GetCategories();

                var ViewModel = categoryList.Select(x => new CategoryViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Description = x.Description
                }).ToList();

                return View(ViewModel);
            }


            [HttpGet]
            public IActionResult New()
            {
                return View("Form", new CategoryFormViewModel());
            }

            [HttpPost]
            public IActionResult Save(CategoryFormViewModel formData)
            {
                if (!ModelState.IsValid)
                {
                    return View("Form", formData);
                }
                var categoryDto = new CategoryDto
                {
                    Id = formData.Id,
                    Name = formData.Name,
                    Description = formData.Description
                };

                if (formData.Id == 0)
                {


                    var response = _categoryService.AddCategory(categoryDto);

                    if (response.IsSucceed)
                    {
                        return RedirectToAction("Index");

                    }
                    else
                    {
                        ViewBag.ErrorMessage = response.Message;
                        return View("form", formData);
                    }
                }
                else
                {

                    _categoryService.EditCategory(categoryDto);

                    return RedirectToAction("Index");

                }









            }

            public IActionResult Edit(int id)
            {
                var category = _categoryService.GetCategoryById(id);

                var viewModel = new CategoryFormViewModel()
                {
                    Id = category.Id,
                    Name = category.Name,
                    Description = category.Description
                };

                return View("Form", viewModel);
            }

            public IActionResult Delete(int id)
            {
                _categoryService.DeleteCategory(id);
                return RedirectToAction("Index");
            }




        }
    }

