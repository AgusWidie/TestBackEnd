using System.Threading;
using System.Threading.Tasks;
using WebSchool.Models;

namespace WebSchool.Service.Interface
{
    public interface IPenggunaService
    {
        Task<GlobalObjectListResponseJson<Pengguna>> CheckAddPengguna(CheckPenggunaModel model, CancellationToken cancellationToken = default);
        Task<GlobalResponseJson> AddPengguna(PenggunaInputModel model, CancellationToken cancellationToken = default);
        Task<GlobalResponseJson> UpdatePengguna(PenggunaUpdateModel model, CancellationToken cancellationToken = default);
        Task<GlobalObjectListResponseJson<Pengguna>> ListPengguna(long id, CancellationToken cancellationToken = default);
    }
}
