using Backend_School.WebApi.Models.Request;
using Backend_School.WebApi.Models.Response;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Backend_School.WebApi.Services.Interface
{
    public interface IConfigurasiPembayaranService
    {
        Task<IEnumerable<ConfigPembayaranResponse>> GetConfigPembayaranById(IdConfigPembayaranRequest parameter, CancellationToken cancellationToken = default);
        Task<IEnumerable<ConfigPembayaranResponse>> CheckAddConfigPembayaran(CheckConfigurasiPembayaranRequest parameter, CancellationToken cancellationToken = default);
        Task<IEnumerable<ConfigPembayaranResponse>> ConfigPembayaranSearch(SearchConfigPembayaranRequest parameter, CancellationToken cancellationToken = default);
        Task<IEnumerable<ConfigPembayaranResponse>> AddConfigPembayaran(ConfigurasiPembayaranAddRequest parameter, CancellationToken cancellationToken = default);
        Task<IEnumerable<ConfigPembayaranResponse>> EditConfigPembayaran(ConfigurasiPembayaranUpdateRequest parameter, CancellationToken cancellationToken = default);
        Task<int> DeleteConfigPembayaran(long Id, CancellationToken cancellationToken = default);
    }
}
