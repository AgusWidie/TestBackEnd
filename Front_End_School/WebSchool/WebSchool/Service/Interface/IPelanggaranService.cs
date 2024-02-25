using System.Threading;
using System.Threading.Tasks;
using WebSchool.Models;

namespace WebSchool.Service.Interface
{
    public interface IPelanggaranService
    {
        Task<GlobalObjectListResponseJson<Pelanggaran>> CheckAddPelanggaran(CheckPelanggaranModel model, CancellationToken cancellationToken = default);
        Task<GlobalResponseJson> AddPelanggaran(PelanggaranInputModel model, CancellationToken cancellationToken = default);
        Task<GlobalResponseJson> UpdatePelanggaran(PelanggaranUpdateModel model, CancellationToken cancellationToken = default);
        Task<GlobalObjectListResponseJson<Pelanggaran>> ListPelanggaran(long id, CancellationToken cancellationToken = default);
    }
}
