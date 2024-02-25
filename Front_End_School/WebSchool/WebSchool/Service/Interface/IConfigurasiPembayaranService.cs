using System.Threading;
using System.Threading.Tasks;
using WebSchool.Models;

namespace WebSchool.Service.Interface
{
    public interface IConfigurasiPembayaranService
    {
        Task<GlobalObjectListResponseJson<ConfigurasiPembayaran>> CheckAddConfigPembayaran(CheckConfigurasiPembayaranModel model, CancellationToken cancellationToken = default);
        Task<GlobalResponseJson> AddConfigPembayaran(ConfigurasiPembayaranInputModel model, CancellationToken cancellationToken = default);
        Task<GlobalResponseJson> UpdateConfigPembayaran(ConfigurasiPembayaranUpdateModel model, CancellationToken cancellationToken = default);
        Task<GlobalResponseJson> DeleteConfigurasiPembayaran(IdConfigurasiPembayaran model, CancellationToken cancellationToken = default);
        Task<GlobalObjectListResponseJson<ConfigurasiPembayaran>> ListConfigurasiPembayaran(long id, CancellationToken cancellationToken = default);
        Task<GlobalObjectListResponseJson<ConfigurasiPembayaran>> ConfigurasiPembayaranSearch(SearchConfigPembayaran model, CancellationToken cancellationToken = default);
    }
}
