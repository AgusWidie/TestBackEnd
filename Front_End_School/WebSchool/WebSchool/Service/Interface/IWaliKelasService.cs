using System.Threading;
using System.Threading.Tasks;
using WebSchool.Models;

namespace WebSchool.Service.Interface
{
    public interface IWaliKelasService
    {
        Task<GlobalObjectListResponseJson<WaliKelas>> CheckAddWaliKelas(CheckWaliKelasModel model, CancellationToken cancellationToken = default);
        Task<GlobalResponseJson> AddWaliKelas(WaliKelasInputModel model, CancellationToken cancellationToken = default);
        Task<GlobalResponseJson> UpdateWaliKelas(WaliKelasUpdateModel model, CancellationToken cancellationToken = default);
        Task<GlobalObjectListResponseJson<WaliKelas>> WaliKelasSearch(SearchWaliKelas model, CancellationToken cancellationToken = default);
        Task<GlobalResponseJson> DeleteWaliKelas(IdWaliKelas model, CancellationToken cancellationToken = default);
    }
}
