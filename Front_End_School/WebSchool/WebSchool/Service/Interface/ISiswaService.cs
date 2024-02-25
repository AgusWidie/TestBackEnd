using System.Threading;
using System.Threading.Tasks;
using WebSchool.Models;

namespace WebSchool.Service.Interface
{
    public interface ISiswaService
    {
        Task<GlobalObjectListResponseJson<Siswa>> CheckAddSiswa(CheckSiswaModel model, CancellationToken cancellationToken = default);
        Task<GlobalResponseJson> AddSiswa(SiswaInputModel model, CancellationToken cancellationToken = default);
        Task<GlobalResponseJson> UpdateSiswa(SiswaUpdateModel model, CancellationToken cancellationToken = default);
        Task<GlobalObjectListResponseJson<Siswa>> SiswaSearch(SearchSiswa model, CancellationToken cancellationToken = default);
    }
}
