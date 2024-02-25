using System.Threading;
using System.Threading.Tasks;
using WebSchool.Models;

namespace WebSchool.Service.Interface
{
    public interface IJadwalPiketGuruService
    {
        Task<GlobalObjectListResponseJson<JadwalPiketGuru>> CheckAddJadwalPiketGuru(CheckJadwalPiketGuruInputModel model, CancellationToken cancellationToken = default);
        Task<GlobalResponseJson> AddJadwalPiketGuru(JadwalPiketGuruInputModel model, CancellationToken cancellationToken = default);
        Task<GlobalResponseJson> UpdateJadwalPiketGuru(JadwalPiketGuruUpdateModel model, CancellationToken cancellationToken = default);
        Task<GlobalObjectListResponseJson<JadwalPiketGuru>> JadwalPiketGuruSearch(SearchJadwalPiketGuru model, CancellationToken cancellationToken = default);
        Task<GlobalResponseJson> DeleteJadwalPiketGuru(IdJadwalPiketGuru model, CancellationToken cancellationToken = default);
    }
}
