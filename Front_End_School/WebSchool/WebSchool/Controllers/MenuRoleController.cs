using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
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
    public class MenuRoleController : Controller
    {
        private readonly ILogger<MenuRoleController> _logger;
        private readonly IMenuRoleService _apiMenuRoleService;
        private readonly IGetMenuService _apiGetMenuService;
        private MenuAction mnuController = new MenuAction();
        public MenuRoleController(ILogger<MenuRoleController> logger, IMenuRoleService apiMenuRoleService, IGetMenuService apiGetMenuService)
        {
            _logger = logger;
            _apiMenuRoleService = apiMenuRoleService;
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

        [HttpPost]
        public async Task<CreateResponse> AddMenuRole([FromBody] MenuRoleInputModel model, CancellationToken cancellationToken)
        {
            CreateResponse msg = new CreateResponse();


            if (ModelState.IsValid)
            {
                CheckMenuRoleModel Check = new CheckMenuRoleModel();
                Check.IdRole = model.IdRole;
                Check.IdMenu = model.IdMenu;

                var CheckData = await _apiMenuRoleService.CheckAddMenuRole(Check);
                if (CheckData.Error)
                {
                    msg.success = false;
                    msg.message = CheckData.Message;
                    return msg;
                }

                if (CheckData.Data.Any())
                {
                    msg.success = false;
                    msg.message = "Data Pengguna Peran Sudah Ada...!";
                    return msg;
                }

                var apiResponse = await _apiMenuRoleService.AddMenuRole(model, cancellationToken);
                if (apiResponse.Error)
                {
                    msg.success = false;
                    msg.message = apiResponse.Message;
                    return msg;
                }

                msg.success = true;
                msg.message = apiResponse.Message;
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
