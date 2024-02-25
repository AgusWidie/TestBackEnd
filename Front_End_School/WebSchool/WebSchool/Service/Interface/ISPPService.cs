using System.Threading;
using System.Threading.Tasks;
using WebSchool.Models;

namespace WebSchool.Service.Interface
{
    public interface ISPPService
    {
        Task<GlobalObjectListResponseJson<SPP>> CheckAddSPP(CheckSPPModel model, CancellationToken cancellationToken = default);
        Task<GlobalResponseJson> AddSPP(SPPInputModel model, CancellationToken cancellationToken = default);
        Task<GlobalResponseJson> UpdateSPP(SPPUpdateModel model, CancellationToken cancellationToken = default);
        Task<GlobalObjectListResponseJson<SPP>> SPPSearch(SearchSPP model, CancellationToken cancellationToken = default);
        Task<GlobalResponseJson> DeleteSPP(IdSPP model, CancellationToken cancellationToken = default);
    }
}
