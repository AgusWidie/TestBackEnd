using Backend_School.WebApi.Models.Request;
using Backend_School.WebApi.Models.Response;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Backend_School.WebApi.Services.Interface
{
    public interface IAbsenGuruService
    {
        Task<IEnumerable<AbsenGuruResponse>> GetAbsenGuruSearch(SearchAbsenGuruRequest parameter, CancellationToken cancellationToken = default);
        Task<IEnumerable<AbsenGuruResponse>> CheckAddAbsenGuru(CheckAbsenGuruRequest parameter, CancellationToken cancellationToken = default);
        Task<IEnumerable<AbsenGuruResponse>> AddAbsenGuru(AbsenGuruAddRequest parameter, CancellationToken cancellationToken = default);
        Task<IEnumerable<AbsenGuruResponse>> EditAbsenGuru(AbsenGuruUpdateRequest parameter, CancellationToken cancellationToken = default);
        Task<int> DeleteAbsenGuru(long Id, CancellationToken cancellationToken = default);
    }
}
