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
    public class PenilaianSiswaController : Controller
    {
        private readonly ILogger<PenilaianSiswaController> _logger;
        private readonly IPenilaianSiswaService _apiPenilaianSiswaService;
        private readonly IGetMenuService _apiGetMenuService;
        private MenuAction mnuController = new MenuAction();
        public PenilaianSiswaController(ILogger<PenilaianSiswaController> logger, IPenilaianSiswaService apiPenilaianSiswaService, IGetMenuService apiGetMenuService)
        {
            _logger = logger;
            _apiPenilaianSiswaService = apiPenilaianSiswaService;
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
        public async Task<GlobalObjectListResponseJson<PenilaianSiswa>> PenilaianSiswaSearch(SearchPenilaianSiswa model, CancellationToken cancellationToken)
        {
            var apiResponse = await _apiPenilaianSiswaService.PenilaianSiswaSearch(model, cancellationToken);
            return apiResponse;
        }

        [HttpPost]
        public async Task<CreateResponse> AddPenilaianSiswa([FromBody] PenilaianSiswaInputModel model, CancellationToken cancellationToken)
        {
            CheckPenilaianSiswaModel Check = new CheckPenilaianSiswaModel();
            Check.IdSiswa = model.IdSiswa;
            Check.IdKelas = model.IdKelas;
            Check.IdTahunAjaran = model.IdTahunAjaran;
            Check.IdPenilaian = model.IdPenilaian;


            CreateResponse msg = new CreateResponse();

            var CheckData = await _apiPenilaianSiswaService.CheckAddPenilaianSiswa(Check);
            if (CheckData.Error)
            {
                msg.success = false;
                msg.message = CheckData.Message;
                return msg;
            }

            if (CheckData.Data.Any())
            {
                msg.success = false;
                msg.message = "Data Penilaian Siswa Sudah Ada...!";
                return msg;
            }

            var apiResponse = await _apiPenilaianSiswaService.AddPenilaianSiswa(model, cancellationToken);
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

        [HttpPost]
        public async Task<UpdateResponse> UpdatePenilaianSiswa([FromBody] PenilaianSiswaUpdateModel model, CancellationToken cancellationToken)
        {

            UpdateResponse msg = new UpdateResponse();
            var apiResponse = await _apiPenilaianSiswaService.UpdatePenilaianSiswa(model, cancellationToken);
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

        [HttpPost]
        public async Task<DeleteResponse> DeletePenilaianSiswa([FromBody] IdPenilaianSiswa model, CancellationToken cancellationToken)
        {

            DeleteResponse msg = new DeleteResponse();

            if (ModelState.IsValid)
            {

                var apiResponse = await _apiPenilaianSiswaService.DeletePenilaianSiswa(model, cancellationToken);
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
