using System.Threading.Tasks;
using System.Threading;
using WebSchool.Models;

namespace WebSchool.Service
{
    public interface ILoginPenggunaService
    {
        Task<string> LoginPengguna(CancellationToken cancellationToken = default);
    }
}
