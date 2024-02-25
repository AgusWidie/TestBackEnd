using System.Threading;
using System.Threading.Tasks;
using Backend_School.WebApi.Models.Request;
using Backend_School.WebApi.Models.Response;
using System.Collections.Generic;

namespace Backend_School.WebApi.Services.Interface
{
    public interface IDataConfigPembayaranService
    {
        Task<IEnumerable<DataConfigPembayaranResponse>> GetIdConfigPembayaran(IdConfigPembayaranRequest parameter, CancellationToken cancellationToken = default);
        Task<IEnumerable<DataConfigPembayaranResponse>> GetNamaConfigPembayaran(NamaConfigPembayaranRequest parameter, CancellationToken cancellationToken = default);
    }
}
