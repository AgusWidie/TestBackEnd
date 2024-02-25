using System.Threading;
using System.Threading.Tasks;
using WebSchool.Models;

namespace WebSchool.Service.Interface
{
    public interface IMenuRoleService
    {

        Task<GlobalObjectListResponseJson<MenuRole>> CheckAddMenuRole(CheckMenuRoleModel model, CancellationToken cancellationToken = default);
        Task<GlobalObjectListResponseJson<MenuRole>> AddMenuRole(MenuRoleInputModel model, CancellationToken cancellationToken = default);
    }
}
