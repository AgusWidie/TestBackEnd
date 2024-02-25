using System.Threading;
using System.Threading.Tasks;
using WebSchool.Models;

namespace WebSchool.Service.Interface
{
    public interface IRaportSiswaService
    {
        Task<GlobalObjectListResponseJson<RaportSiswa>> CheckAddRaportSiswa(CheckRaportSiswaModel model, CancellationToken cancellationToken = default);
        Task<GlobalResponseJson> AddRaportSiswa(RaportSiswaInputModel model, CancellationToken cancellationToken = default);
        Task<GlobalResponseJson> UpdateRaportSiswa(RaportSiswaUpdateModel model, CancellationToken cancellationToken = default);
        Task<GlobalResponseJson> DeleteRaportSiswa(IdRaportSiswa model, CancellationToken cancellationToken = default);
        Task<GlobalObjectListResponseJson<RaportSiswa>> RaportSiswaSearch(SearchRaportSiswa model, CancellationToken cancellationToken = default);
    }
}
