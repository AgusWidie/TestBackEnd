using System.Threading;
using System.Threading.Tasks;
using WebSchool.Models;

namespace WebSchool.Service.Interface
{
    public interface IPenilaianSiswaService
    {
        Task<GlobalObjectListResponseJson<PenilaianSiswa>> CheckAddPenilaianSiswa(CheckPenilaianSiswaModel model, CancellationToken cancellationToken = default);
        Task<GlobalResponseJson> AddPenilaianSiswa(PenilaianSiswaInputModel model, CancellationToken cancellationToken = default);
        Task<GlobalResponseJson> UpdatePenilaianSiswa(PenilaianSiswaUpdateModel model, CancellationToken cancellationToken = default);
        Task<GlobalResponseJson> DeletePenilaianSiswa(IdPenilaianSiswa model, CancellationToken cancellationToken = default);
        Task<GlobalObjectListResponseJson<PenilaianSiswa>> PenilaianSiswaSearch(SearchPenilaianSiswa model, CancellationToken cancellationToken = default);
    }
}
