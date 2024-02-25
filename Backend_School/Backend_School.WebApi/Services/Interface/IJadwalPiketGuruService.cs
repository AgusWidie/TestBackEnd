using Backend_School.WebApi.Models.Request;
using Backend_School.WebApi.Models.Response;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Backend_School.WebApi.Services.Interface
{
    public interface IJadwalPiketGuruService
    {
        Task<IEnumerable<JadwalPiketGuruResponse>> CheckAddJadwalPiketGuru(CheckJadwalPiketGuruRequest parameter, CancellationToken cancellationToken = default);
        Task<IEnumerable<JadwalPiketGuruResponse>> GetJadwalPiketGuruSearch(SearchJadwalPiketGuruRequest parameter, CancellationToken cancellationToken = default);
        Task<IEnumerable<JadwalPiketGuruResponse>> AddJadwalPiket(JadwalPiketGuruAddRequest parameter, CancellationToken cancellationToken = default);
        Task<IEnumerable<JadwalPiketGuruResponse>> UpdateJadwalPiket(JadwalPiketGuruUpdateRequest parameter, CancellationToken cancellationToken = default);
        Task<int> DeleteJadwalPiketGuru(long Id, CancellationToken cancellationToken = default);
    }
}
