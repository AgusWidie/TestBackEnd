using Backend_School.WebApi.Models.Request;
using Backend_School.WebApi.Models.Response;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Backend_School.WebApi.Services.Interface
{
    public interface IWaliKelasService
    {
        Task<IEnumerable<WaliKelasResponse>> GetWaliKelasSearch(SearchWaliKelasRequest parameter, CancellationToken cancellationToken = default);
        Task<IEnumerable<WaliKelasResponse>> CheckAddWaliKelas(CheckWaliKelasRequest parameter, CancellationToken cancellationToken = default);
        Task<IEnumerable<WaliKelasResponse>> AddWaliKelas(WaliKelasAddRequest parameter, CancellationToken cancellationToken = default);
        Task<IEnumerable<WaliKelasResponse>> EditWaliKelas(WaliKelasUpdateRequest parameter, CancellationToken cancellationToken = default);
        Task<int> DeleteWaliKelas(long Id, CancellationToken cancellationToken = default);
    }
}
