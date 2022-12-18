using Cheapla.Business.Services;
using Cheapla.Data.Dto;
using Cheapla.WebUI.Models;
using Microsoft.AspNetCore.Mvc;

namespace Cheapla.WebUI.Controllers
{
    public class ChangePasswordController : Controller
    {

       private readonly IUserService _userService;

        public ChangePasswordController(IUserService userService)
        {
            _userService=userService;
        }

   
        [HttpGet]
        [Route("Güncelle")]
        public IActionResult ChangeUpdate()
        {
            var user = _userService.GetUserById(Convert.ToInt32(User.Claims.FirstOrDefault(x => x.Type == "id").Value));



            var viewModel = new ChangePasswordViewModel
            {

                Id = user.Id,
                LastPassword=user.Password,
            };
            return View(viewModel);
        }


        [HttpPost]
        [Route("Güncelle")]
        public IActionResult ChangeUpdate(ChangePasswordViewModel formData)
        {
            var user = _userService.GetUserById(Convert.ToInt32(User.Claims.FirstOrDefault(x => x.Type == "id").Value));



            if (!ModelState.IsValid)
            {
                return View("ChangeUpdate", formData);
            }
            if (formData.LastPassword!=user.Password)
            {
                ViewBag.ErrorMessage = "Şifre Güncel Şifre İle Uyuşmuyor!";
                return View("ChangeUpdate",formData);
            }



            var userDto = new UserDto
            {
                Id = formData.Id,
                Password = formData.Password,
                
               
                
            };

           _userService.UpdateUserPassword(userDto);


            TempData["UpdateMessage"] = "Şifre başarıyla değiştirildi";


            return RedirectToAction("Index", "Home");
        }

    }
}
