using Backend_School.WebApi.Models.Response;
using Backend_School.WebApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;

namespace Backend_School.WebApi.Services.Interface
{
    public interface IGetMenuService
    {
        Task<IEnumerable<MenuResponse>> GetMenuController(MenuActionRequest parameter, CancellationToken cancellationToken = default);
    }
}
