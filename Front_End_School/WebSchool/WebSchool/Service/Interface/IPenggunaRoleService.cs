using System.Threading;
using System.Threading.Tasks;
using WebSchool.Models;

namespace WebSchool.Service.Interface
{
    public interface IPenggunaRoleService
    {
        Task<GlobalObjectListResponseJson<PenggunaRole>> CheckAddPenggunaRole(CheckPenggunaRoleModel model, CancellationToken cancellationToken = default);
        Task<GlobalResponseJson> AddPenggunaRole(PenggunaRoleInputModel model, CancellationToken cancellationToken = default);
        Task<GlobalResponseJson> UpdatePenggunaRole(PenggunaRoleUpdateModel model, CancellationToken cancellationToken = default);
        Task<GlobalObjectListResponseJson<PenggunaRole>> ListPenggunaRole(long id, CancellationToken cancellationToken = default);
    }
}
