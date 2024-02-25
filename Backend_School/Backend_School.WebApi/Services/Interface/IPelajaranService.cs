using System.Threading;
using System.Threading.Tasks;
using Backend_School.WebApi.Models.Request;
using Backend_School.WebApi.Models.Response;
using System.Collections.Generic;

namespace Backend_School.WebApi.Services.Interface
{
    public interface IPelajaranService
    {
        Task<IEnumerable<PelajaranResponse>> GetPelajaranById(IdPelajaranRequest parameter, CancellationToken cancellationToken = default);
        Task<IEnumerable<PelajaranResponse>> CheckAddPelajaran(CheckPelajaranRequest parameter, CancellationToken cancellationToken = default);
        Task<IEnumerable<PelajaranResponse>> AddPelajaran(PelajaranAddRequest parameter, CancellationToken cancellationToken = default);
        Task<IEnumerable<PelajaranResponse>> EditPelajaran(PelajaranUpdateRequest parameter, CancellationToken cancellationToken = default);
        Task<int> DeletePelajaran(long Id, CancellationToken cancellationToken = default);
    }
}
