using Backend_School.WebApi.Models.Request;
using Backend_School.WebApi.Models.Response;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Backend_School.WebApi.Services.Interface
{
    public interface IPelanggaranSiswaService
    {
        Task<IEnumerable<PelanggaranSiswaResponse>> GetPelanggaranSiswaSearch(SearchPelanggaranSiswaRequest parameter, CancellationToken cancellationToken = default);
        Task<IEnumerable<PelanggaranSiswaResponse>> AddPelanggaranSiswa(PelanggaranSiswaAddRequest parameter, CancellationToken cancellationToken = default);
        Task<IEnumerable<PelanggaranSiswaResponse>> EditPelanggaranSiswa(PelanggaranSiswaUpdateRequest parameter, CancellationToken cancellationToken);
        Task<int> DeletePelanggaranSiswa(long Id, CancellationToken cancellationToken = default);
    }
}
