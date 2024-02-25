using System.Threading;
using System.Threading.Tasks;
using Backend_School.WebApi.Models.Request;
using Backend_School.WebApi.Models.Response;
using System.Collections.Generic;

namespace Backend_School.WebApi.Services.Interface
{
    public interface ITahunAjaranService
    {
        Task<IEnumerable<TahunAjaranResponse>> GetTahunAjaranById(IdTahunAjaranRequest parameter, CancellationToken cancellationToken = default);
        Task<IEnumerable<TahunAjaranResponse>> CheckAddTahunAjaran(CheckTahunAjaranRequest parameter, CancellationToken cancellationToken = default);
        Task<IEnumerable<TahunAjaranResponse>> AddTahunAjaran(TahunAjaranAddRequest parameter, CancellationToken cancellationToken = default);
        Task<IEnumerable<TahunAjaranResponse>> EditTahunAjaran(TahunAjaranUpdateRequest parameter, CancellationToken cancellationToken = default);
        Task<int> DeleteTahunAjaran(long Id, CancellationToken cancellationToken = default);
    }
}
