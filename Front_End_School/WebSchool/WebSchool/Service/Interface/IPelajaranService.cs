using System.Threading;
using System.Threading.Tasks;
using WebSchool.Models;

namespace WebSchool.Service.Interface
{
    public interface IPelajaranService
    {
        Task<GlobalObjectListResponseJson<Pelajaran>> CheckAddPelajaran(CheckPelajaranModel model, CancellationToken cancellationToken = default);
        Task<GlobalResponseJson> AddPelajaran(PelajaranInputModel model, CancellationToken cancellationToken = default);
        Task<GlobalResponseJson> UpdatePelajaran(PelajaranUpdateModel model, CancellationToken cancellationToken = default);
        Task<GlobalObjectListResponseJson<Pelajaran>> ListPelajaran(long id, CancellationToken cancellationToken = default);
    }
}
