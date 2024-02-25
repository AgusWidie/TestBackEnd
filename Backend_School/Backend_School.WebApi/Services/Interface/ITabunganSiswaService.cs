using Backend_School.WebApi.Models.Request;
using Backend_School.WebApi.Models.Response;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Backend_School.WebApi.Services.Interface
{
    public interface ITabunganSiswaService
    {
        Task<IEnumerable<TabunganSiswaResponse>> GetTabunganSiswaSearch(SearchTabunganSiswaRequest parameter, CancellationToken cancellationToken = default);
        Task<IEnumerable<TabunganSiswaResponse>> AddTabunganSiswa(TabunganSiswaAddRequest parameter, CancellationToken cancellationToken = default);
        Task<IEnumerable<TabunganSiswaResponse>> EditTabunganSiswa(TabunganSiswaUpdateRequest parameter, CancellationToken cancellationToken = default);
        Task<IEnumerable<TotalTabunganSiswaRsponse>> TotalTabunganSiswa(SearchTabunganSiswaRequest parameter, CancellationToken cancellationToken = default);
        Task<int> DeleteTabunganSiswa(long Id, CancellationToken cancellationToken = default);
    }
}
