using Backend_School.WebApi.Models.Request;
using Backend_School.WebApi.Models.Response;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Backend_School.WebApi.Services.Interface
{
    public interface IAbsenSiswaService
    {
        Task<IEnumerable<AbsenSiswaResponse>> GetAbsenSiswaSearch(SearchAbsenSiswaRequest paremeter, CancellationToken cancellationToken = default);
        Task<IEnumerable<AbsenSiswaResponse>> CheckAddAbsenSiswa(CheckAbsenSiswaRequest paremeter, CancellationToken cancellationToken = default);
        Task<IEnumerable<AbsenSiswaResponse>> AddAbsenSiswa(AbsenSiswaAddRequest parameter, CancellationToken cancellationToken = default);
        Task<IEnumerable<AbsenSiswaResponse>> EditAbsenSiswa(AbsenSiswaUpdateRequest parameter, CancellationToken cancellationToken = default);
        Task<int> DeleteAbsenSiswa(long Id, CancellationToken cancellationToken = default);
    }
}
