using System.Threading;
using System.Threading.Tasks;
using Backend_School.WebApi.Models.Request;
using Backend_School.WebApi.Models.Response;
using System.Collections.Generic;

namespace Backend_School.WebApi.Services.Interface
{
    public interface IMenuRoleService
    {
        Task<IEnumerable<MenuRoleResponse>> GetMenuRoleById(IdMenuRoleRequest request, CancellationToken cancellationToken = default);
        Task<IEnumerable<MenuRoleResponse>> CheckAddMenuRole(CheckMenuRoleRequest parameter, CancellationToken cancellationToken = default);
        Task<IEnumerable<MenuRoleResponse>> AddMenuRole(MenuRoleAddRequest parameter, CancellationToken cancellationToken = default);
        Task<IEnumerable<MenuRoleResponse>> EditMenuRole(MenuRoleUpdateRequest parameter, CancellationToken cancellationToken = default);
        Task<int> DeleteMenuRole(long Id, CancellationToken cancellationToken = default);
    }
}
