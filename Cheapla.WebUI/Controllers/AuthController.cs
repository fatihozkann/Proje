﻿using Cheapla.Business.Services;
using Cheapla.Data.Entities;
using Cheapla.WebUI.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Cheapla.WebUI.Controllers
{
    public class AuthController : Controller
    {
        private readonly IUserService _userService;
        private readonly ICartService _cartService;
        public AuthController(IUserService userService, ICartService cartService)
        {
            _userService = userService;
           _cartService = cartService;
        }


        [Route("Kayıt-Ol")]
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [Route("Kayıt-Ol")]
        [HttpPost]
        public IActionResult Register(RegisterViewModel formData)
        {

            if (!ModelState.IsValid)
            {
                return View(formData);
            }
            var user = new UserEntity
            {
                FirstName = formData.FirstName.Trim(),
                LastName = formData.LastName.Trim(),
                Email = formData.Email.Trim(),
                Password = formData.Password.Trim(),
                UserType = Data.Enums.UserTypeEnum.user


            };

            var response = _userService.AddUser(user);

            if (response.IsSucceed)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.ErrorMessage = response.Message;
                return View(formData);
            }






        }
        public async Task<IActionResult> Login(LoginViewModel formData)
        {
            var user = _userService.Login(formData.Email, formData.Password);

            if (user is null)
            {
                TempData["LoginMessage"] = "Kullanıcı adı veya şifreyi hatalı girdiniz!!";

                return RedirectToAction("Index", "Home");
            }
          
            var claims = new List<Claim>();

            claims.Add(new Claim("id", user.Id.ToString()));
            claims.Add(new Claim("firstName", user.FirstName));
            claims.Add(new Claim("lastName", user.LastName));
            claims.Add(new Claim("email", user.Email));
            claims.Add(new Claim("userType", user.UserType.ToString()));

            claims.Add(new Claim(ClaimTypes.Role, user.UserType.ToString()));

            var claimIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            var autProperties = new AuthenticationProperties
            {
                AllowRefresh = true,
                ExpiresUtc = new DateTimeOffset(DateTime.Now.AddHours(48))
            };

            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimIdentity),
                autProperties);
            _cartService.InitializeCart(user.Id);

            return RedirectToAction("Index", "Home");


        }
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();

            return RedirectToAction("Index", "Home");
        }
    }

}
