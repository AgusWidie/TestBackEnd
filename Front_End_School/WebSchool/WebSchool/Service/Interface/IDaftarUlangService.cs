using System.Threading;
using System.Threading.Tasks;
using WebSchool.Models;

namespace WebSchool.Service.Interface
{
    public interface IDaftarUlangService
    {
        Task<GlobalObjectListResponseJson<DaftarUlang>> CheckAddDaftarUlang(CheckDaftarUlangModel model, CancellationToken cancellationToken = default);
        Task<GlobalResponseJson> AddDaftarUlang(DaftarUlangInputModel model, CancellationToken cancellationToken = default);
        Task<GlobalResponseJson> UpdateDaftarUlang(DaftarUlangUpdateModel model, CancellationToken cancellationToken = default);
        Task<GlobalObjectListResponseJson<DaftarUlang>> DaftarUlangSearch(SearchDaftarUlang model, CancellationToken cancellationToken = default);
        Task<GlobalResponseJson> DeleteDaftarUlang(IdDaftarUlang model, CancellationToken cancellationToken = default);
    }
}
