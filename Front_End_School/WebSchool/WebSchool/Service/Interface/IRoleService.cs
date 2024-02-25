using System.Threading;
using System.Threading.Tasks;
using WebSchool.Models;

namespace WebSchool.Service.Interface
{
    public interface IRoleService
    {
        Task<GlobalObjectListResponseJson<Role>> CheckAddRole(CheckRoleModel model, CancellationToken cancellationToken = default);
        Task<GlobalResponseJson> AddRole(RoleInputModel model, CancellationToken cancellationToken = default);
        Task<GlobalResponseJson> UpdateRole(RoleUpdateModel model, CancellationToken cancellationToken = default);
        Task<GlobalObjectListResponseJson<Role>> ListRole(long id, CancellationToken cancellationToken = default);
    }
}
