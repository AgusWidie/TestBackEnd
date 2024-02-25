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
    public class PelajaranController : Controller
    {
        private readonly ILogger<PelajaranController> _logger;
        private readonly IPelajaranService _apiPelajaranService;
        private readonly IGetMenuService _apiGetMenuService;
        private MenuAction mnuController = new MenuAction();
        public PelajaranController(ILogger<PelajaranController> logger, IPelajaranService apiPelajaranService, IGetMenuService apiGetMenuService)
        {
            _logger = logger;
            _apiPelajaranService = apiPelajaranService;
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
        public async Task<GlobalObjectListResponseJson<Pelajaran>> ListPelajaran(long id, CancellationToken cancellationToken)
        {
            var apiResponse = await _apiPelajaranService.ListPelajaran(id, cancellationToken);
            return apiResponse;
        }

        [HttpPost]
        public async Task<CreateResponse> AddPelajaran([FromBody] PelajaranInputModel model, CancellationToken cancellationToken)
        {
            CreateResponse msg = new CreateResponse();

            if(ModelState.IsValid)
            {
                CheckPelajaranModel Check = new CheckPelajaranModel();
                Check.NamaPelajaran = model.NamaPelajaran;

                var CheckData = await _apiPelajaranService.CheckAddPelajaran(Check);
                if (CheckData.Error)
                {
                    msg.success = false;
                    msg.message = CheckData.Message;
                    return msg;
                }

                if (CheckData.Data.Any())
                {
                    msg.success = false;
                    msg.message = "Data Pelajaran Sudah Ada...!";
                    return msg;
                }

                var apiResponse = await _apiPelajaranService.AddPelajaran(model, cancellationToken);
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
        public async Task<UpdateResponse> UpdatePelajaran([FromBody] PelajaranUpdateModel model, CancellationToken cancellationToken)
        {

            UpdateResponse msg = new UpdateResponse();

            if(ModelState.IsValid)
            {
                var apiResponse = await _apiPelajaranService.UpdatePelajaran(model, cancellationToken);
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
