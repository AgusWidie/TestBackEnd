using System.Threading;
using System.Threading.Tasks;
using Backend_School.WebApi.Models.Request;
using Backend_School.WebApi.Models.Response;
using System.Collections.Generic;

namespace Backend_School.WebApi.Services.Interface
{
    public interface IKelasService
    {
        Task<IEnumerable<KelasResponse>> GetKelasById(IdKelasRequest parameter, CancellationToken cancellationToken = default);
        Task<IEnumerable<KelasResponse>> GetKelasByPengguna(PenggunaKelasRequest parameter, CancellationToken cancellationToken = default);
        Task<IEnumerable<KelasResponse>> CheckAddKelas(CheckKelasRequest parameter, CancellationToken cancellationToken = default);
        Task<IEnumerable<KelasResponse>> AddKelas(KelasAddRequest parameter, CancellationToken cancellationToken = default);
        Task<IEnumerable<KelasResponse>> EditKelas(KelasUpdateRequest parameter, CancellationToken cancellationToken = default);
        Task<int> DeleteKelas(long Id, CancellationToken cancellationToken = default);
    }
}
