using System.Threading;
using System.Threading.Tasks;
using WebSchool.Models;

namespace WebSchool.Service.Interface
{
    public interface IPembayaranService
    {
        Task<GlobalObjectListResponseJson<Pembayaran>> CheckAddPembayaran(CheckPembayaranModel model, CancellationToken cancellationToken = default);
        Task<GlobalResponseJson> AddPembayaran(PembayaranInputModel model, CancellationToken cancellationToken = default);
        Task<GlobalResponseJson> UpdatePembayaran(PembayaranUpdateModel model, CancellationToken cancellationToken = default);
        Task<GlobalObjectListResponseJson<Pembayaran>> PembayaranSearch(SearchPembayaran model, CancellationToken cancellationToken = default);
        Task<GlobalResponseJson> DeletePembayaran(IdPembayaran model, CancellationToken cancellationToken = default);
    }
}
