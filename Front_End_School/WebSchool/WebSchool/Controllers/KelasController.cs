using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using WebSchool.Models;
using WebSchool.Service.Interface;

namespace WebSchool.Controllers
{
    //[Authentication]
    public class KelasController : Controller
    {
        private readonly ILogger<KelasController> _logger;
        private readonly IKelasService _apiKelasService;
        private readonly IGetMenuService _apiGetMenuService;
        private MenuAction mnuController = new MenuAction();
        public KelasController(ILogger<KelasController> logger, IKelasService apiKelasService, IGetMenuService apiGetMenuService)
        {
            _logger = logger;
            _apiKelasService = apiKelasService;
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
        public async Task<GlobalObjectListResponseJson<Kelas>> ListKelas(long id, CancellationToken cancellationToken)
        {
            var apiResponse = await _apiKelasService.ListKelas(id, cancellationToken);
            return apiResponse;
        }

        [HttpGet]
        public async Task<GlobalObjectListResponseJson<Kelas>> ListKelasPengguna(CancellationToken cancellationToken)
        {
            var apiResponse = await _apiKelasService.ListKelasPengguna(cancellationToken);
            return apiResponse;
        }

        [HttpPost]
        public async Task<CreateResponse> AddKelas([FromBody] KelasInputModel model, CancellationToken cancellationToken)
        {
            CreateResponse msg = new CreateResponse();

            if (ModelState.IsValid)
            {
                CheckKelasModel Check = new CheckKelasModel();
                Check.NamaKelas = model.NamaKelas;

                var CheckData = await _apiKelasService.CheckAddKelas(Check);
                if (CheckData.Error)
                {
                    msg.success = false;
                    msg.message = CheckData.Message;
                    return msg;
                }

                if (CheckData.Data.Any())
                {
                    msg.success = false;
                    msg.message = "Data Kelas Sudah Ada...!";
                    return msg;
                }

                var apiResponse = await _apiKelasService.AddKelas(model, cancellationToken);
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
        public async Task<UpdateResponse> UpdateKelas([FromBody] KelasUpdateModel model, CancellationToken cancellationToken)
        {

            UpdateResponse msg = new UpdateResponse();

            if (ModelState.IsValid)
            {
                var apiResponse = await _apiKelasService.UpdateKelas(model, cancellationToken);
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
