using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using WebSchool.Auth;
using WebSchool.Models;
using WebSchool.Service.Interface;

namespace WebSchool.Controllers
{
    [Authentication]
    public class UangBangunanController : Controller
    {
        private readonly ILogger<UangBangunanController> _logger;
        private readonly IUangBangunanService _apiUangBangunanService;
        private readonly IGetMenuService _apiGetMenuService;
        private MenuAction mnuController = new MenuAction();
        public UangBangunanController(ILogger<UangBangunanController> logger, IUangBangunanService apiUangBangunanService, IGetMenuService apiGetMenuService)
        {
            _logger = logger;
            _apiUangBangunanService = apiUangBangunanService;
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
        public async Task<GlobalObjectListResponseJson<UangBangunan>> UangBangunanSearch(SearchUangBangunan model, CancellationToken cancellationToken)
        {
            var apiResponse = await _apiUangBangunanService.UangBangunanSearch(model, cancellationToken);
            return apiResponse;
        }

        [HttpPost]
        public async Task<GlobalObjectListResponseJson<TotalUangBangunanSiswa>> TotalUangBangunan([FromBody] TotalUangBangunanInputModel model, CancellationToken cancellationToken)
        {

            var apiResponse = await _apiUangBangunanService.TotalUangBangunanSiswa(model, cancellationToken);
            return apiResponse;

        }

        [HttpPost]
        public async Task<CreateResponse> AddUangBangunan([FromBody] UangBangunanInputModel model, CancellationToken cancellationToken)
        {

            CreateResponse msg = new CreateResponse();

            if (ModelState.IsValid)
            {
                var apiResponse = await _apiUangBangunanService.AddUangBangunan(model, cancellationToken);
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
        public async Task<UpdateResponse> UpdateUangBangunan([FromBody] UangBangunanUpdateModel model, CancellationToken cancellationToken)
        {

            UpdateResponse msg = new UpdateResponse();

            if (ModelState.IsValid)
            {
                var apiResponse = await _apiUangBangunanService.UpdateUangBangunan(model, cancellationToken);
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
        public async Task<DeleteResponse> DeleteUangBangunan([FromBody] IdUangBangunan model, CancellationToken cancellationToken)
        {

            DeleteResponse msg = new DeleteResponse();

            if (ModelState.IsValid)
            {

                var apiResponse = await _apiUangBangunanService.DeleteUangBangunan(model, cancellationToken);
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
