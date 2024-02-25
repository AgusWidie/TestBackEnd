using System.Threading;
using System.Threading.Tasks;
using WebSchool.Models;

namespace WebSchool.Service.Interface
{
    public interface ITahunAjarService
    {
        Task<GlobalObjectListResponseJson<TahunAjar>> CheckAddTahunAjaran(CheckTahunAjaranModel model, CancellationToken cancellationToken = default);
        Task<GlobalResponseJson> AddTahunAjaran(TahunAjaranInputModel model, CancellationToken cancellationToken = default);
        Task<GlobalResponseJson> UpdateTahunAjaran(TahunAjaranUpdateModel model, CancellationToken cancellationToken = default);
        Task<GlobalObjectListResponseJson<TahunAjar>> ListTahunAjaran(long id, CancellationToken cancellationToken = default);
    }
}
