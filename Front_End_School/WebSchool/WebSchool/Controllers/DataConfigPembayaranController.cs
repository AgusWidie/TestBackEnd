using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using WebSchool.Auth;
using WebSchool.Models;
using WebSchool.Models.Admin.DataConfigPembayaran;
using WebSchool.Service.Interface;

namespace WebSchool.Controllers
{
    [Authentication]
    public class DataConfigPembayaranController : Controller
    {
        private readonly ILogger<DataConfigPembayaranController> _logger;
        private readonly IDataConfigPembayaranService _apidataConfigPembayaranService;
        private readonly IGetMenuService _apiGetMenuService;
        private MenuAction mnuController = new MenuAction();
        public DataConfigPembayaranController(ILogger<DataConfigPembayaranController> logger, IDataConfigPembayaranService apidataConfigPembayaranService, IGetMenuService apiGetMenuService)
        {
            _logger = logger;
            _apidataConfigPembayaranService = apidataConfigPembayaranService;
            _apiGetMenuService = apiGetMenuService;
        }

        [HttpPost]
        public async Task<GlobalObjectListResponseJson<DataConfigPembayaran>> DataConfigPembayaranById(IdConfigPembayaran model, CancellationToken cancellationToken)
        {
            var apiResponse = await _apidataConfigPembayaranService.DataConfigPembayaranById(model, cancellationToken);
            return apiResponse;
        }

        [HttpPost]
        public async Task<GlobalObjectListResponseJson<DataConfigPembayaran>> DataConfigPembayaranByNama(NamaConfigPembayaran model, CancellationToken cancellationToken)
        {
            var apiResponse = await _apidataConfigPembayaranService.DataConfigPembayaranByNama(model, cancellationToken);
            return apiResponse;
        }
    }
}
