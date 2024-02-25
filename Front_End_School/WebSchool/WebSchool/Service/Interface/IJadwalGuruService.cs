using System.Threading;
using System.Threading.Tasks;
using WebSchool.Models;

namespace WebSchool.Service.Interface
{
    public interface IJadwalGuruService
    {
        Task<GlobalObjectListResponseJson<JadwalGuru>> CheckAddJadwalGuru(CheckJadwalGuruInputModel model, CancellationToken cancellationToken = default);
        Task<GlobalResponseJson> AddJadwalGuru(JadwalGuruInputModel model, CancellationToken cancellationToken = default);
        Task<GlobalResponseJson> UpdateJadwalGuru(JadwalGuruUpdateModel model, CancellationToken cancellationToken = default);
        Task<GlobalObjectListResponseJson<JadwalGuru>> JadwalGuruSearch(SearchJadwalGuru model, CancellationToken cancellationToken = default);
        Task<GlobalResponseJson> DeleteJadwalGuru(IdJadwalGuru model, CancellationToken cancellationToken = default);
    }
}
