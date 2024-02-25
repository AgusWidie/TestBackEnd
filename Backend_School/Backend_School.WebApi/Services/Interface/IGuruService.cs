using Backend_School.WebApi.Models.Request;
using Backend_School.WebApi.Models.Response;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Backend_School.WebApi.Services.Interface
{
    public interface IGuruService
    {
        Task<IEnumerable<GuruResponse>> GetGuruById(IdGuruRequest parameter, CancellationToken cancellationToken = default);
        Task<IEnumerable<GuruResponse>> CheckAddGuru(CheckGuruRequest parameter, CancellationToken cancellationToken = default);
        Task<string> GenerateNomorIndukPegawai(CancellationToken cancellationToken = default);
        Task<IEnumerable<GuruResponse>> AddGuru(GuruAddRequest parameter, CancellationToken cancellationToken = default);
        Task<IEnumerable<GuruResponse>> AddPhotoGuru(GuruAddPhotoRequest parameter, CancellationToken cancellationToken = default);
        Task<IEnumerable<GuruResponse>> EditGuru(GuruUpdateRequest parameter, CancellationToken cancellationToken = default);
        Task<IEnumerable<GuruResponse>> EditPhotoGuru(GuruUpdatePhotoRequest parameter, CancellationToken cancellationToken = default);
        Task<int> DeleteGuru(long Id, CancellationToken cancellationToken = default);
    }
}
