using System.Threading;
using System.Threading.Tasks;
using WebSchool.Models;

namespace WebSchool.Service.Interface
{
    public interface IAbsenSiswaService
    {
        Task<GlobalObjectListResponseJson<AbsenSiswa>> CheckAddAbsenSiswa(CheckAddAbsenSiswaModel model, CancellationToken cancellationToken = default);
        Task<GlobalResponseJson> AddAbsenSiswa(AbsenSiswaInputModel model, CancellationToken cancellationToken = default);
        Task<GlobalResponseJson> UpdateAbsenSiswa(AbsenSiswaUpdateModel model, CancellationToken cancellationToken = default);
        Task<GlobalObjectListResponseJson<AbsenSiswa>> AbsenSiswaSearch(SearchAbsenSiswa model, CancellationToken cancellationToken = default);
    }
}
