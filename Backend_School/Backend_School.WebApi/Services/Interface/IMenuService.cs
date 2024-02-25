using System.Threading;
using System.Threading.Tasks;
using Backend_School.WebApi.Models.Request;
using Backend_School.WebApi.Models.Response;
using System.Collections.Generic;

namespace Backend_School.WebApi.Services.Interface
{
    public interface IMenuService
    {
        Task<IEnumerable<MenuResponse>> GetMenuById(IdMenuRequest parameter, CancellationToken cancellationToken = default);
        Task<IEnumerable<MenuResponse>> AddMenu(MenuAddRequest parameter, CancellationToken cancellationToken = default);
        Task<IEnumerable<MenuResponse>> EditMenu(MenuUpdateRequest parameter, CancellationToken cancellationToken = default);
        Task<int> DeleteMenu(long Id, CancellationToken cancellationToken = default);
    }
}
