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
    public class LoginController : Controller
    {
        private readonly ILogger<LoginController> _logger;
        private readonly ILoginService _apiLoginService;

        public LoginController(ILogger<LoginController> logger, ILoginService apiLoginService)
        {
            _logger = logger;
            _apiLoginService = apiLoginService;
        }

        public async Task<IActionResult> Index(CancellationToken cancellationToken)
        {
            var apiResponse = await _apiLoginService.ConnectDB(cancellationToken);
            if (apiResponse.error)
            {
                return RedirectToAction("Index", "Error");
            }
            return View();

        }

        public async Task<IActionResult> Register(CancellationToken cancellationToken)
        {
            var apiResponse = await _apiLoginService.ConnectDB(cancellationToken);
            if (apiResponse.error)
            {
                return RedirectToAction("Index", "Error");
            }
            return View();
        }

        [HttpPost]
        public async Task<GlobalResponseJson> LoginPengguna([FromBody] LoginModel model, CancellationToken cancellationToken)
        {
            GlobalResponseJson res = new GlobalResponseJson();
            if (ModelState.IsValid)
            {
                string NamaPengguna = "";
                string Role = "";

                if (HttpContext.Session.GetString("UserName") != null)
                {
                    HttpContext.Session.Remove("UserName");
                    HttpContext.Session.Clear();
                }

                var apiResponse = await _apiLoginService.LoginPengguna(model, cancellationToken);
                if (apiResponse.Error)
                {
                    res.error = true;
                    res.message = "Error Login";
                    res.code = 400;
                    return res;
                }
                else
                {
                    if (apiResponse.Data.Any())
                    {
                        foreach (var Data in apiResponse.Data)
                        {
                            NamaPengguna = Data.NamaPengguna;
                            Role = Data.NamaRole;
                        }

                        var claims = new List<Claim>() {
                        new Claim(ClaimTypes.NameIdentifier, NamaPengguna),
                        new Claim(ClaimTypes.Role, Role)
                    };
                        //var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                        //var principal = new ClaimsPrincipal(identity);
                        //await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, new AuthenticationProperties() { IsPersistent = true });

                        HttpContext.Session.SetString("UserName", NamaPengguna);

                        res.error = false;
                        res.message = "Berhasil Login..!";
                        res.code = 200;
                        return res;
                    }
                    else
                    {
                        res.error = true;
                        res.message = "Nama Pengguna Tidak Terdaftar/Password Salah..!";
                        res.code = 200;
                        return res;
                    }
                }
            }
            else
            {
                res.error = false;
                res.message = "bad request..!";
                res.code = 400;
                return res;
            }
        }
    }
}
