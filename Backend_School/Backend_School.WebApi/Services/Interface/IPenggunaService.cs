using System.Threading;
using System.Threading.Tasks;
using Backend_School.WebApi.Models.Request;
using Backend_School.WebApi.Models.Response;
using System.Collections.Generic;

namespace Backend_School.WebApi.Services.Interface
{
    public interface IPenggunaService
    {
        Task<IEnumerable<PenggunaResponse>> GetPenggunaById(IdPenggunaRequest request, CancellationToken cancellationToken = default);
        Task<IEnumerable<PenggunaResponse>> CheckAddPengguna(CheckPenggunaRequest parameter, CancellationToken cancellationToken = default);
        Task<IEnumerable<PenggunaResponse>> AddPengguna(PenggunaAddRequest parameter, CancellationToken cancellationToken = default);
        Task<IEnumerable<PenggunaResponse>> EditPengguna(PenggunaUpdateRequest parameter, CancellationToken cancellationToken = default);
        Task<int> DeletePengguna(long Id, CancellationToken cancellationToken = default);
    }
}
