﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace Cheapla.WebUI.Areas.Admin.Controllers
{

        [Area("Admin")]
        [Authorize(Roles = "admin")]
        public class BaseController : Controller
        {

        }
    

}
