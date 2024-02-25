using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System.Threading;
using WebSchool.Models;
using WebSchool.Service;
using WebSchool.Service.Interface;
using WebSchool.Models.Admin.Tahun;
using WebSchool.Auth;

namespace WebSchool.Controllers
{
    [Authentication]
    public class TahunController
    {
        private readonly ILogger<TahunController> _logger;
        private readonly ITahunService _apiTahunService;
        private readonly IGetMenuService _apiGetMenuService;
        private MenuAction mnuController = new MenuAction();
        public TahunController(ILogger<TahunController> logger, ITahunService apiTahunService, IGetMenuService apiGetMenuService)
        {
            _logger = logger;
            _apiTahunService = apiTahunService;
            _apiGetMenuService = apiGetMenuService;
        }

        [HttpGet]
        public async Task<GlobalObjectListResponseJson<Tahunn>> ListTahun(CancellationToken cancellationToken)
        {
            var apiResponse = await _apiTahunService.ListTahun(cancellationToken);
            return apiResponse;
        }
    }
}
