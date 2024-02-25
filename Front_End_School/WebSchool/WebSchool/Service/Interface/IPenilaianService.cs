using System.Threading;
using System.Threading.Tasks;
using WebSchool.Models;

namespace WebSchool.Service.Interface
{
    public interface IPenilaianService
    {
        Task<GlobalObjectListResponseJson<Penilaian>> CheckAddPenilaian(CheckPenilaianModel model, CancellationToken cancellationToken = default);
        Task<GlobalResponseJson> AddPenilaian(PenilaianInputModel model, CancellationToken cancellationToken = default);
        Task<GlobalResponseJson> UpdatePenilaian(PenilaianUpdateModel model, CancellationToken cancellationToken = default);
        Task<GlobalObjectListResponseJson<Penilaian>> ListPenilaian(long id, CancellationToken cancellationToken = default);
    }
}
