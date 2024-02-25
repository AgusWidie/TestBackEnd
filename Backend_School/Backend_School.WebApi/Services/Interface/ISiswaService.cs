using Backend_School.WebApi.Models.Request;
using Backend_School.WebApi.Models.Response;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Backend_School.WebApi.Services.Interface
{
    public interface ISiswaService
    {
        Task<IEnumerable<SiswaResponse>> GetSiswaSearch(SearchSiswaRequest parameter, CancellationToken cancellationToken = default);
        Task<IEnumerable<SiswaResponse>> CheckAddSiswa(CheckSiswaRequest parameter, CancellationToken cancellationToken = default);
        Task<IEnumerable<SiswaResponse>> AddSiswa(SiswaAddRequest parameter, CancellationToken cancellationToken = default);
        Task<string> GenerateNomorIndukSiswa(CancellationToken cancellationToken = default);
        Task<IEnumerable<SiswaResponse>> AddPhotoSiswa(SiswaAddPhotoRequest parameter, CancellationToken cancellationToken = default);
        Task<IEnumerable<SiswaResponse>> EditPhotoSiswa(SiswaUpdatePhotoRequest parameter, CancellationToken cancellationToken = default);
        Task<IEnumerable<SiswaResponse>> EditSiswa(SiswaUpdateRequest parameter, CancellationToken cancellationToken = default);
        Task<int> DeleteSiswa(long Id, CancellationToken cancellationToken = default);
    }
}
