using System.Threading;
using System.Threading.Tasks;
using WebSchool.Models;

namespace WebSchool.Service.Interface
{
    public interface IAbsenGuruService
    {
        Task<GlobalObjectListResponseJson<AbsenGuru>> CheckAddAbsenGuru(CheckAddAbsenGuruModel model, CancellationToken cancellationToken = default);
        Task<GlobalResponseJson> AddAbsenGuru(AbsenGuruInputModel model, CancellationToken cancellationToken = default);
        Task<GlobalResponseJson> UpdateAbsenGuru(AbsenGuruUpdateModel model, CancellationToken cancellationToken = default);
        Task<GlobalObjectListResponseJson<AbsenGuru>> AbsenGuruSearch(SearchAbsenGuru model, CancellationToken cancellationToken = default);
    }
}
