using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using WebSchool.Auth;
using WebSchool.Models;
using WebSchool.Service;
using WebSchool.Service.Interface;

namespace WebSchool.Controllers
{
    public class ChangePasswordController : Controller
    {
        private readonly ILogger<ChangePasswordController> _logger;
        private readonly IChangePasswordService _apiChangePasswordService;
        private readonly IGetMenuService _apiGetMenuService;
        private MenuAction mnuController = new MenuAction();

        public ChangePasswordController(ILogger<ChangePasswordController> logger, IGetMenuService apiGetMenuService)
        {
            _logger = logger;
            _apiGetMenuService = apiGetMenuService;
        }

        public async Task<IActionResult> Index(CancellationToken cancellationToken)
        {
            try
            {
                string controllerName = this.ControllerContext.RouteData.Values["controller"].ToString();
                var NamaPengguna = User.FindFirstValue(ClaimTypes.NameIdentifier);
                mnuController.ControllerName = controllerName;
                //ViewBag.MenuController = _apiGetMenuService.GetMenuController(mnuController);

                return View();
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Error");
            }
        }

        [HttpPost]
        public async Task<CreateResponse> GantiPassword([FromBody] ChangePassword model, CancellationToken cancellationToken)
        {
            CreateResponse msg = new CreateResponse();
            if (ModelState.IsValid)
            {

                var apiResponse = await _apiChangePasswordService.GantiPassword(model, cancellationToken);
                if (apiResponse.error)
                {
                    msg.success = false;
                    msg.message = apiResponse.message;
                    return msg;
                }

                msg.success = true;
                msg.message = apiResponse.message;
                return msg;
            }
            else
            {
                msg.success = false;
                msg.message = "bad request...!";
                return msg;
            }

        }
    }
}
