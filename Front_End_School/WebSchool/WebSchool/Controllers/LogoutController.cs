using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using WebSchool.Models;
using WebSchool.Service;


namespace WebSchool.Controllers
{
    public class LogoutController : Controller
    {
        private readonly ILogger<LogoutController> _logger;
        public LogoutController(ILogger<LogoutController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public async Task<GlobalResponseJson> LogoutPengguna(CancellationToken cancellationToken)
        {
            GlobalResponseJson res = new GlobalResponseJson();
            HttpContext.Session.Remove("UserName");
            HttpContext.Session.Clear();
            res.error = false;
            res.message = "Berhasil Logout..!";
            res.code = 200;
            return res;
          
            //return RedirectToAction("Index", "Login");
        }
    }
}
