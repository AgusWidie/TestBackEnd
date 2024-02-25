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
    public class GuruController : Controller
    {
        private readonly ILogger<GuruController> _logger;
        private readonly IGuruService _apiGuruService;
        private readonly IGetMenuService _apiGetMenuService;
        private MenuAction mnuController = new MenuAction();
        public GuruController(ILogger<GuruController> logger, IGuruService apiGuruService, IGetMenuService apiGetMenuService)
        {
            _logger = logger;
            _apiGuruService = apiGuruService;
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
        public async Task<GlobalObjectListResponseJson<Guru>> ListGuru(long id, CancellationToken cancellationToken)
        {
            var apiResponse = await _apiGuruService.ListGuru(id, cancellationToken);
            return apiResponse;
        }

        [HttpPost]
        public async Task<CreateResponse> AddGuru([FromBody] GuruInputModel model, CancellationToken cancellationToken)
        {
            CreateResponse msg = new CreateResponse();

            if (ModelState.IsValid)
            {
                CheckGuruModel Check = new CheckGuruModel();
                Check.NoKTP = model.NoKTP;

                var CheckData = await _apiGuruService.CheckAddGuru(Check);
                if (CheckData.Error)
                {
                    msg.success = false;
                    msg.message = CheckData.Message;
                    return msg;
                }

                if (CheckData.Data.Any())
                {
                    msg.success = false;
                    msg.message = "Data Guru Sudah Ada...!";
                    return msg;
                }

                var apiResponse = await _apiGuruService.AddGuru(model, cancellationToken);
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
        public async Task<UpdateResponse> UpdateGuru([FromBody] GuruUpdateModel model, CancellationToken cancellationToken)
        {

            UpdateResponse msg = new UpdateResponse();

            if(ModelState.IsValid)
            {
                var apiResponse = await _apiGuruService.UpdateGuru(model, cancellationToken);
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
