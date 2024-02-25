using System.Threading;
using System.Threading.Tasks;
using Backend_School.WebApi.Models.Request;
using Backend_School.WebApi.Models.Response;
using System.Collections.Generic;

namespace Backend_School.WebApi.Services.Interface
{
    public interface IRoleService
    {
        Task<IEnumerable<RoleResponse>> GetRoleById(IdRoleRequest request, CancellationToken cancellationToken = default);
        Task<IEnumerable<RoleResponse>> CheckAddRole(CheckRoleRequest parameter, CancellationToken cancellationToken = default);
        Task<IEnumerable<RoleResponse>> AddRole(RoleAddRequest parameter, CancellationToken cancellationToken = default);
        Task<IEnumerable<RoleResponse>> EditRole(RoleUpdateRequest parameter, CancellationToken cancellationToken = default);
        Task<int> DeleteRole(long Id, CancellationToken cancellationToken = default);
    }
}
