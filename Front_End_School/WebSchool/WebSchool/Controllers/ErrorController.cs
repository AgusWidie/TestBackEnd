using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using WebSchool.Auth;
using WebSchool.Models;
using WebSchool.Service.Interface;

namespace WebSchool.Controllers
{
    [Authentication]
    public class ErrorController : Controller
    {
        private readonly ILogger<ErrorController> _logger;
        private readonly IGetMenuService _apiGetMenuService;
        private MenuAction mnuController = new MenuAction();

        public ErrorController(ILogger<ErrorController> logger, IGetMenuService apiGetMenuService)
        {
            _logger = logger;
            _apiGetMenuService = apiGetMenuService;
        }

        public async Task<IActionResult> Index(CancellationToken cancellationToken)
        {
            string controllerName = this.ControllerContext.RouteData.Values["controller"].ToString();
            var NamaPengguna = User.FindFirstValue(ClaimTypes.NameIdentifier);
            mnuController.ControllerName = controllerName;
            ViewBag.MenuController = _apiGetMenuService.GetMenuController(mnuController);

            return View();
        }

        public async Task<IActionResult> ListError(CancellationToken cancellationToken)
        {
            string controllerName = this.ControllerContext.RouteData.Values["controller"].ToString();
            var NamaPengguna = User.FindFirstValue(ClaimTypes.NameIdentifier);
            mnuController.ControllerName = controllerName;
            ViewBag.MenuController = _apiGetMenuService.GetMenuController(mnuController);

            return View();
        }
    }
}
