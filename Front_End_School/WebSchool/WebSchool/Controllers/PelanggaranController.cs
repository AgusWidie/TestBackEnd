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
    public class PelanggaranController : Controller
    {
        private readonly ILogger<PelanggaranController> _logger;
        private readonly IPelanggaranService _apiPelanggaranService;
        private readonly IGetMenuService _apiGetMenuService;
        private MenuAction mnuController = new MenuAction();
        public PelanggaranController(ILogger<PelanggaranController> logger, IPelanggaranService apiPelanggaranService, IGetMenuService apiGetMenuService)
        {
            _logger = logger;
            _apiPelanggaranService = apiPelanggaranService;
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
        public async Task<GlobalObjectListResponseJson<Pelanggaran>> ListPelanggaran(long id, CancellationToken cancellationToken)
        {
            string controllerName = this.ControllerContext.RouteData.Values["controller"].ToString();
            var apiResponse = await _apiPelanggaranService.ListPelanggaran(id, cancellationToken);
            return apiResponse;
        }

        [HttpPost]
        public async Task<CreateResponse> AddPelanggaran([FromBody] PelanggaranInputModel model, CancellationToken cancellationToken)
        {

            CreateResponse msg = new CreateResponse();

            if(ModelState.IsValid)
            {
                CheckPelanggaranModel Check = new CheckPelanggaranModel();
                Check.NamaPelanggaran = model.NamaPelanggaran;

                var CheckData = await _apiPelanggaranService.CheckAddPelanggaran(Check);
                if (CheckData.Error)
                {
                    msg.success = false;
                    msg.message = CheckData.Message;
                    return msg;
                }

                if (CheckData.Data.Any())
                {
                    msg.success = false;
                    msg.message = "Data Pelanggaran Sudah Ada...!";
                    return msg;
                }

                var apiResponse = await _apiPelanggaranService.AddPelanggaran(model, cancellationToken);
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
        public async Task<UpdateResponse> UpdatePelanggaran([FromBody] PelanggaranUpdateModel model, CancellationToken cancellationToken)
        {
            UpdateResponse msg = new UpdateResponse();
            if (ModelState.IsValid)
            {
                var apiResponse = await _apiPelanggaranService.UpdatePelanggaran(model, cancellationToken);
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
