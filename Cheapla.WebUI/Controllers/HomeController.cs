using Cheapla.Business.Services;
using Cheapla.Data.Dto;
using Cheapla.Data.Entities;
using Cheapla.WebUI.Models;
using Microsoft.AspNetCore.Mvc;
using PagedList;

namespace Cheapla.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductService _productService;

        private readonly IUserService _userService;

        private readonly ICommentService _commentService;

        public HomeController(IProductService productService, IUserService userService, ICommentService commentService)
        {
            _productService = productService;
            _userService = userService;
            _commentService = commentService;
        }

        [Route("/")]
        [Route("urunler/{categoryName}/{categoryId}")]
        public IActionResult Index(int? categoryId)
        {
            ViewBag.CategoryId = categoryId;

            var viewModel = new ProductListViewModel
            {
                Products = _productService.GetAllProduct().Products
            };

            return View(viewModel);
        }
        

        [Route("Detail")]
        [HttpGet]
        public IActionResult Details(int id)
        {
            var products = _productService.GetProductById(id);

            

            var viewModel = new DetailViewModel
            {
                Id = products.Id,
                Name = products.Name,
                UnitPrice = products.UnitPrice,
                ImagePath = products.ImagePath,
                Description = products.Description,
                UnitInStock = products.UnitInStock,
                Summary = products.Summary,
                

            };

           
            return View(viewModel);
        }


        [HttpGet]
        public IActionResult New(int id)
        {
            
            var comments = _commentService.GetCommentById(id);
            var viewModel = new CommentFormViewModel
            {
                Id = comments.Id,
                UserName = comments.UserName,
                CommentContent= comments.CommentContent,
               


            };

            return View("Details", viewModel);
        }

        [HttpPost]
        public IActionResult New(CommentFormViewModel formData, int id)
        {
          

            if (!ModelState.IsValid)
            {
                return View("Details", formData);
            }

            var commentDto = new CommentDto()

            {
                
                CommentContent = formData.CommentContent,
                UserName = formData.UserName,             
                ProductId=formData.Id,
                UserId = Convert.ToInt32(User.Claims.FirstOrDefault(x => x.Type == "id")?.Value),
                

            };

            if (formData.Id != 0)
            {


                var response = _commentService.AddComment(commentDto);


                if (response.IsSucceed)
                {
                    TempData["UpdateMessage"] = "Yorumunuz başarıyla alındı";
                    return RedirectToAction("Index", "Home");

                }
                else
                {
                    ViewBag.ErrorMessage = response.Message;
                    return View("Details", formData);
                }
            }
            else
            {
                return RedirectToAction("Index");
            }

        }
        public IActionResult Save()
        {
            return View();
        }
    }

}

