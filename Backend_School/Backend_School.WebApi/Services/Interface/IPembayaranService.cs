using Backend_School.WebApi.Models.Request;
using Backend_School.WebApi.Models.Response;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Backend_School.WebApi.Services.Interface
{
    public interface IPembayaranService
    {
        Task<IEnumerable<PembayaranResponse>> GetPembayaranSearch(SearchPembayaranRequest parameter, CancellationToken cancellationToken = default);
        Task<IEnumerable<PembayaranResponse>> CheckAddPembayaran(CheckPembayaranRequest parameter, CancellationToken cancellationToken = default);
        Task<IEnumerable<PembayaranResponse>> AddPembayaran(PembayaranAddRequest parameter, CancellationToken cancellationToken = default);
        Task<IEnumerable<PembayaranResponse>> EditPembayaran(PembayaranUpdateRequest parameter, CancellationToken cancellationToken = default);
        Task<int> DeletePembayaran(long Id, CancellationToken cancellationToken = default);
    }
}
