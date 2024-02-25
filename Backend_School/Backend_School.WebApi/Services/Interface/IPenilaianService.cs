using System.Threading;
using System.Threading.Tasks;
using Backend_School.WebApi.Models.Request;
using Backend_School.WebApi.Models.Response;
using System.Collections.Generic;

namespace Backend_School.WebApi.Services.Interface
{
    public interface IPenilaianService
    {
        Task<IEnumerable<PenilaianResponse>> GetPenilaianById(IdPenilaianRequest parameter, CancellationToken cancellationToken = default);
        Task<IEnumerable<PenilaianResponse>> CheckAddPenilaian(CheckPenilaianRequest parameter, CancellationToken cancellationToken = default);
        Task<IEnumerable<PenilaianResponse>> AddPenilaian(PenilaianAddRequest parameter, CancellationToken cancellationToken = default);
        Task<IEnumerable<PenilaianResponse>> EditPenilaian(PenilaianUpdateRequest parameter, CancellationToken cancellationToken = default);
        Task<int> DeletePenilaian(long Id, CancellationToken cancellationToken = default);
    }
}
