using System.Threading;
using System.Threading.Tasks;
using WebSchool.Models;


namespace WebSchool.Service.Interface
{
    public interface IMenuPenggunaRoleService
    {
        Task<GlobalObjectListResponseJson<Menu>> ListMenuPengguna(CheckTokenModel model, CancellationToken cancellationToken = default);
    }
}
