using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using WebSchool.Auth;
using WebSchool.Models;

namespace WebSchool.Controllers
{
    [Authentication]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> Index(CancellationToken cancellationToken)
        {
            string controllerName = this.ControllerContext.RouteData.Values["controller"].ToString();
            var NamaPengguna = User.FindFirstValue(ClaimTypes.NameIdentifier);
            return View();
        }

        public IActionResult Privacy()
        {
            var NamaPengguna = User.FindFirstValue(ClaimTypes.NameIdentifier);
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
