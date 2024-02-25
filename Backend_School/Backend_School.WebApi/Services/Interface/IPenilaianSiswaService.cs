using Backend_School.WebApi.Models.Request;
using Backend_School.WebApi.Models.Response;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Backend_School.WebApi.Services.Interface
{
    public interface IPenilaianSiswaService
    {
        Task<IEnumerable<PenilaianSiswaResponse>> GetPenilaianSiswaSearch(SearchPenilaianSiswaRequest parameter, CancellationToken cancellationToken = default);
        Task<IEnumerable<PenilaianSiswaResponse>> CheckAddPenilaianSiswa(CheckPenilaianSiswaRequest parameter, CancellationToken cancellationToken = default);
        Task<IEnumerable<PenilaianSiswaResponse>> AddPenilaianSiswa(PenilaianSiswaAddRequest parameter, CancellationToken cancellationToken = default);
        Task<IEnumerable<PenilaianSiswaResponse>> EditPenilaianSiswa(PenilaianSiswaUpdateRequest parameter, CancellationToken cancellationToken = default);
        Task<int> DeletePenilaianSiswa(long Id, CancellationToken cancellationToken = default);
    }
}
