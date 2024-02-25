using System.Threading;
using System.Threading.Tasks;
using Backend_School.WebApi.Models.Request;
using Backend_School.WebApi.Models.Response;
using System.Collections.Generic;

namespace Backend_School.WebApi.Services.Interface
{
    public interface IPelanggaranService
    {
        Task<IEnumerable<PelanggaranResponse>> GetPelanggaranById(IdPelanggaranRequest parameter, CancellationToken cancellationToken = default);
        Task<IEnumerable<PelanggaranResponse>> CheckAddPelanggaran(CheckPelanggaranRequest parameter, CancellationToken cancellationToken = default);
        Task<IEnumerable<PelanggaranResponse>> AddPelanggaran(PelanggaranAddRequest parameter, CancellationToken cancellationToken = default);
        Task<IEnumerable<PelanggaranResponse>> EditPelanggaran(PelanggaranUpdateRequest parameter, CancellationToken cancellationToken = default);
        Task<int> DeletePelanggaran(long Id, CancellationToken cancellationToken = default);
    }
}
