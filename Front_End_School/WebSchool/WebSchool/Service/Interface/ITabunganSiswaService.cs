using System.Threading;
using System.Threading.Tasks;
using WebSchool.Models;

namespace WebSchool.Service.Interface
{
    public interface ITabunganSiswaService
    {
        Task<GlobalResponseJson> AddTabunganSiswa(TabunganSiswaInputModel model, CancellationToken cancellationToken = default);
        Task<GlobalResponseJson> UpdateTabunganSiswa(TabunganSiswaUpdateModel model, CancellationToken cancellationToken = default);
        Task<GlobalResponseJson> DeleteTabunganSiswa(IdTabunganSiswa model, CancellationToken cancellationToken = default);
        Task<GlobalObjectListResponseJson<TabunganSiswa>> TabunganSiswaSearch(SearchTabunganSiswa model, CancellationToken cancellationToken = default);
        Task<GlobalObjectListResponseJson<TotalTabunganSiswa>> TotalTabunganSiswa(SearchTabunganSiswa model, CancellationToken cancellationToken = default);
    }
}
