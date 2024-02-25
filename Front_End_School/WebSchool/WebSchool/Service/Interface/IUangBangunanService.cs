using System.Threading;
using System.Threading.Tasks;
using WebSchool.Models;

namespace WebSchool.Service.Interface
{
    public interface IUangBangunanService
    {
        Task<GlobalResponseJson> AddUangBangunan(UangBangunanInputModel model, CancellationToken cancellationToken = default);
        Task<GlobalResponseJson> UpdateUangBangunan(UangBangunanUpdateModel model, CancellationToken cancellationToken = default);
        Task<GlobalResponseJson> DeleteUangBangunan(IdUangBangunan model, CancellationToken cancellationToken = default);
        Task<GlobalObjectListResponseJson<UangBangunan>> UangBangunanSearch(SearchUangBangunan model, CancellationToken cancellationToken = default);
        Task<GlobalObjectListResponseJson<TotalUangBangunanSiswa>> TotalUangBangunanSiswa(TotalUangBangunanInputModel model, CancellationToken cancellationToken = default);
    }
}
