using System.Threading;
using System.Threading.Tasks;
using WebSchool.Models;

namespace WebSchool.Service.Interface
{
    public interface IPelanggaranSiswaService
    {
        Task<GlobalResponseJson> AddPelanggaranSiswa(PelanggaranSiswaInputModel model, CancellationToken cancellationToken = default);
        Task<GlobalResponseJson> UpdatePelanggaranSiswa(PelanggaranSiswaUpdateModel model, CancellationToken cancellationToken = default);
        Task<GlobalResponseJson> DeletePelanggaranSiswa(IdPelanggaranSiswa model, CancellationToken cancellationToken = default);
        Task<GlobalObjectListResponseJson<PelanggaranSiswa>> PelanggaranSiswaSearch(SearchPelanggaranSiswa model, CancellationToken cancellationToken = default);
    }
}
