using System.Threading;
using System.Threading.Tasks;
using WebSchool.Models;

namespace WebSchool.Service.Interface
{
    public interface IGuruService
    {
        Task<GlobalObjectListResponseJson<Guru>> CheckAddGuru(CheckGuruModel model, CancellationToken cancellationToken = default);
        Task<GlobalResponseJson> AddGuru(GuruInputModel model, CancellationToken cancellationToken = default);
        Task<GlobalResponseJson> UpdateGuru(GuruUpdateModel model, CancellationToken cancellationToken = default);
        Task<GlobalObjectListResponseJson<Guru>> ListGuru(long id, CancellationToken cancellationToken = default);
    }
}
