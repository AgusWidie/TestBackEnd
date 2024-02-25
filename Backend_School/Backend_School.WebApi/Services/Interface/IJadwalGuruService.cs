using Backend_School.WebApi.Models.Request;
using Backend_School.WebApi.Models.Response;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Backend_School.WebApi.Services.Interface
{
    public interface IJadwalGuruService
    {
        Task<IEnumerable<JadwalGuruResponse>> GetJadwalGuruSearch(SearchJadwalGuruRequest request, CancellationToken cancellationToken = default);
        Task<IEnumerable<JadwalGuruResponse>> CheckAddJadwalGuru(CheckJadwalGuruRequest parameter, CancellationToken cancellationToken = default);
        Task<IEnumerable<JadwalGuruResponse>> AddJadwalGuru(JadwalGuruAddRequest parameter, CancellationToken cancellationToken = default);
        Task<IEnumerable<JadwalGuruResponse>> EditJadwalGuru(JadwalGuruUpdateRequest parameter, CancellationToken cancellationToken = default);
        Task<int> DeleteJadwalGuru(long Id, CancellationToken cancellationToken = default);
    }
}
