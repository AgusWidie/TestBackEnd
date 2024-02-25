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
    public class TabunganSiswaController : Controller
    {
        private readonly ILogger<TabunganSiswaController> _logger;
        private readonly ITabunganSiswaService _apiTabunganSiswaService;
        private readonly IGetMenuService _apiGetMenuService;
        private MenuAction mnuController = new MenuAction();

        public TabunganSiswaController(ILogger<TabunganSiswaController> logger, ITabunganSiswaService apiTabunganSiswaService, IGetMenuService apiGetMenuService)
        {
            _logger = logger;
            _apiTabunganSiswaService = apiTabunganSiswaService;
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
        public async Task<GlobalObjectListResponseJson<TabunganSiswa>> TabunganSiswaSearch(SearchTabunganSiswa model, CancellationToken cancellationToken)
        {
            var apiResponse = await _apiTabunganSiswaService.TabunganSiswaSearch(model, cancellationToken);
            return apiResponse;
        }

        [HttpPost]
        public async Task<CreateResponse> AddTabunganSiswa([FromBody] TabunganSiswaInputModel model, CancellationToken cancellationToken)
        {

            CreateResponse msg = new CreateResponse();

            var apiResponse = await _apiTabunganSiswaService.AddTabunganSiswa(model, cancellationToken);
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
        public async Task<UpdateResponse> UpdateTabunganSiswa([FromBody] TabunganSiswaUpdateModel model, CancellationToken cancellationToken)
        {

            UpdateResponse msg = new UpdateResponse();

            if (ModelState.IsValid)
            {
                var apiResponse = await _apiTabunganSiswaService.UpdateTabunganSiswa(model, cancellationToken);
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
        public async Task<DeleteResponse> DeleteTabunganSiswa([FromBody] IdTabunganSiswa model, CancellationToken cancellationToken)
        {

            DeleteResponse msg = new DeleteResponse();

            if (ModelState.IsValid)
            {

                var apiResponse = await _apiTabunganSiswaService.DeleteTabunganSiswa(model, cancellationToken);
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
        public async Task<GlobalObjectListResponseJson<TotalTabunganSiswa>> TotalTabunganSiswa(SearchTabunganSiswa model, CancellationToken cancellationToken)
        {
            var apiResponse = await _apiTabunganSiswaService.TotalTabunganSiswa(model, cancellationToken);
            return apiResponse;
        }
    }
}
