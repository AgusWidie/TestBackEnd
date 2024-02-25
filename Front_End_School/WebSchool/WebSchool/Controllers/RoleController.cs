using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using WebSchool.Auth;
using WebSchool.Models;
using WebSchool.Service.Interface;

namespace WebSchool.Controllers
{
    [Authentication]
    public class RoleController : Controller
    {
        private readonly ILogger<RoleController> _logger;
        private readonly IRoleService _apiRoleService;
        private readonly IGetMenuService _apiGetMenuService;
        private MenuAction mnuController = new MenuAction();
        public RoleController(ILogger<RoleController> logger, IRoleService apiRoleService, IGetMenuService apiGetMenuService)
        {
            _logger = logger;
            _apiRoleService = apiRoleService;
            _apiGetMenuService = apiGetMenuService;
        }

        public async Task<IActionResult> Index(CancellationToken cancellationToken)
        {
            try
            {
                string controllerName = this.ControllerContext.RouteData.Values["controller"].ToString();
                var NamaPengguna = User.FindFirstValue(ClaimTypes.NameIdentifier);
                mnuController.ControllerName = controllerName;
                ViewBag.MenuController = _apiGetMenuService.GetMenuController(mnuController);

                return View();
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Error");
            }
        }

        [HttpGet]
        public async Task<GlobalObjectListResponseJson<Role>> ListRole(long id, CancellationToken cancellationToken)
        {
            var apiResponse = await _apiRoleService.ListRole(id, cancellationToken);
            return apiResponse;
        }

        [HttpPost]
        public async Task<CreateResponse> AddRole([FromBody] RoleInputModel model, CancellationToken cancellationToken)
        {
            CreateResponse msg = new CreateResponse();

            if(ModelState.IsValid)
            {
                CheckRoleModel Check = new CheckRoleModel();
                Check.NamaRole = model.NamaRole;

                var CheckData = await _apiRoleService.CheckAddRole(Check);
                if (CheckData.Error)
                {
                    msg.success = false;
                    msg.message = CheckData.Message;
                    return msg;
                }

                if (CheckData.Data.Any())
                {
                    msg.success = false;
                    msg.message = "Data Peran Sudah Ada...!";
                    return msg;
                }

                var apiResponse = await _apiRoleService.AddRole(model, cancellationToken);
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

        [HttpPost]
        public async Task<UpdateResponse> UpdateRole([FromBody] RoleUpdateModel model, CancellationToken cancellationToken)
        {

            UpdateResponse msg = new UpdateResponse();
            if(ModelState.IsValid)
            {
                var apiResponse = await _apiRoleService.UpdateRole(model, cancellationToken);
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
