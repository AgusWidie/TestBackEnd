using System.Threading;
using System.Threading.Tasks;
using WebSchool.Models;

namespace WebSchool.Service
{
    public interface ILoginService
    {
        Task<GlobalResponseJson> ConnectDB(CancellationToken cancellationToken = default);
        Task<GlobalObjectListResponseJson<Login>> LoginPengguna(LoginModel model, CancellationToken cancellationToken = default);
    }
}
