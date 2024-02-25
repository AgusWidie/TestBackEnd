using Backend_School.WebApi.Models.Request;
using Backend_School.WebApi.Models.Response;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Backend_School.WebApi.Services.Interface
{
    public interface IRaportSiswaService
    {
        Task<IEnumerable<RaportSiswaResponse>> GetRaportSiswaSearch(SearchRaportSiswaRequest parameter, CancellationToken cancellationToken = default);
        Task<IEnumerable<RaportSiswaResponse>> CheckAddRaportSiswa(CheckRaportSiswaRequest parameter, CancellationToken cancellationToken = default);
        Task<IEnumerable<RaportSiswaResponse>> AddRaportSiswa(RaportSiswaAddRequest parameter, CancellationToken cancellationToken = default);
        Task<IEnumerable<RaportSiswaResponse>> EditRaportSiswa(RaportSiswaUpdateRequest parameter, CancellationToken cancellationToken = default);
        Task<int> DeleteRaportSiswa(long Id, CancellationToken cancellationToken = default);
    }
}
