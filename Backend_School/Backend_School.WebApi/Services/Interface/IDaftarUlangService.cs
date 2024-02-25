
using Backend_School.WebApi.Models.Request;
using Backend_School.WebApi.Models.Response;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Backend_School.WebApi.Services.Interface
{
    public interface IDaftarUlangService
    {
        Task<IEnumerable<DaftarUlangResponse>> GetDaftarUlangSearch(SearchDaftarUlangRequest parameter, CancellationToken cancellationToken = default);
        Task<IEnumerable<DaftarUlangResponse>> CheckAddDaftarUlang(CheckDaftarUlangRequest parameter, CancellationToken cancellationToken = default);
        Task<IEnumerable<DaftarUlangResponse>> AddDaftarUlang(DaftarUlangAddRequest parameter, CancellationToken cancellationToken = default);
        Task<IEnumerable<DaftarUlangResponse>> EditDaftarUlang(DaftarUlangUpdateRequest parameter, CancellationToken cancellationToken = default);
        Task<int> DeleteDaftarUlang(long Id, CancellationToken cancellationToken = default);
    }
}
