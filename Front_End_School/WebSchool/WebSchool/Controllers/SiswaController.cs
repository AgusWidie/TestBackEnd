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
    public class SiswaController : Controller
    {
        private readonly ILogger<SiswaController> _logger;
        private readonly ISiswaService _apiSiswaService;
        private readonly IGetMenuService _apiGetMenuService;
        private MenuAction mnuController = new MenuAction();
        public SiswaController(ILogger<SiswaController> logger, ISiswaService apiSiswaService, IGetMenuService apiGetMenuService)
        {
            _logger = logger;
            _apiSiswaService = apiSiswaService;
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

        [HttpPost]
        public async Task<GlobalObjectListResponseJson<Siswa>> SiswaSearch(SearchSiswa model, CancellationToken cancellationToken)
        {
            var apiResponse = await _apiSiswaService.SiswaSearch(model, cancellationToken);
            return apiResponse;
        }

        [HttpPost]
        public async Task<CreateResponse> AddSiswa([FromBody] SiswaInputModel model, CancellationToken cancellationToken)
        {

            CreateResponse msg = new CreateResponse();

            if (ModelState.IsValid)
            {
                CheckSiswaModel Check = new CheckSiswaModel();
                Check.NamaSiswa = model.NamaSiswa;

                var CheckData = await _apiSiswaService.CheckAddSiswa(Check);
                if (CheckData.Error)
                {
                    msg.success = false;
                    msg.message = CheckData.Message;
                    return msg;
                }

                if (CheckData.Data.Any())
                {
                    msg.success = false;
                    msg.message = "Data Siswa Sudah Ada...!";
                    return msg;
                }

                var apiResponse = await _apiSiswaService.AddSiswa(model, cancellationToken);
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
        public async Task<UpdateResponse> UpdateSiswa([FromBody] SiswaUpdateModel model, CancellationToken cancellationToken)
        {

            UpdateResponse msg = new UpdateResponse();

            if (ModelState.IsValid)
            {
                var apiResponse = await _apiSiswaService.UpdateSiswa(model, cancellationToken);
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
