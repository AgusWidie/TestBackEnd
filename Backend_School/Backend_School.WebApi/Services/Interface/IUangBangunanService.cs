using Backend_School.WebApi.Models.Request;
using Backend_School.WebApi.Models.Response;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Backend_School.WebApi.Services.Interface
{
    public interface IUangBangunanService
    {
        Task<IEnumerable<UangBangunanResponse>> GetUangBangunanSearch(SearchUangBangunanRequest parameter, CancellationToken cancellationToken = default);
        Task<IEnumerable<TotalUangBangunanResponse>> TotalUangBangunan(TotalUangBangunanRequest parameter, CancellationToken cancellationToken = default);
        Task<IEnumerable<UangBangunanResponse>> AddUangBangunan(UangBangunanAddRequest parameter, CancellationToken cancellationToken = default);
        Task<IEnumerable<UangBangunanResponse>> EditUangBangunan(UangBangunanUpdateRequest parameter, CancellationToken cancellationToken = default);
        Task<int> DeleteUangBangunan(long Id, CancellationToken cancellationToken = default);
    }
}
