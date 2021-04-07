using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using litsey.Models;

namespace litsey.Controllers
{
    public class LoginController : Controller
    {
        private readonly ILogger<LoginController> _logger;

        public LoginController(ILogger<LoginController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult SignIn(User user)
        {
            if(ModelState.IsValid)
            {
                if(user.Name=="admin" && user.Password=="1234")
                    return View(user);
            }
            return View("Index",user);
        }

    }
}
