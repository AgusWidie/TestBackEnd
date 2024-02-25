using System.Threading;
using System.Threading.Tasks;
using WebSchool.Models;

namespace WebSchool.Service.Interface
{
    public interface IKelasService
    {
        Task<GlobalObjectListResponseJson<Kelas>> CheckAddKelas(CheckKelasModel model, CancellationToken cancellationToken = default);
        Task<GlobalResponseJson> AddKelas(KelasInputModel model, CancellationToken cancellationToken = default);
        Task<GlobalResponseJson> UpdateKelas(KelasUpdateModel model, CancellationToken cancellationToken = default);
        Task<GlobalObjectListResponseJson<Kelas>> ListKelas(long id, CancellationToken cancellationToken = default);
        Task<GlobalObjectListResponseJson<Kelas>> ListKelasPengguna(CancellationToken cancellationToken = default);
    }
}
