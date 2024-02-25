using Backend_School.WebApi.Models.Request;
using Backend_School.WebApi.Models.Response;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Backend_School.WebApi.Services.Interface
{
    public interface ISPPService
    {
        Task<IEnumerable<SPPResponse>> GetSPPSearch(SearchSPPRequest parameter, CancellationToken cancellationToken = default);
        Task<IEnumerable<SPPResponse>> CheckAddSPP(CheckSPPRequest parameter, CancellationToken cancellationToken = default);
        Task<IEnumerable<BulanResponse>> CheckBulanSPPSiswa(CheckSPPRequest parameter, CancellationToken cancellationToken = default);
        Task<IEnumerable<SPPResponse>> AddSPP(SPPAddRequest parameter, CancellationToken cancellationToken = default);
        Task<IEnumerable<SPPResponse>> EditSPP(SPPUpdateRequest parameter, CancellationToken cancellationToken = default);
        Task<int> DeleteSPP(long Id, CancellationToken cancellationToken = default);
    }
}
