using System.Threading;
using System.Threading.Tasks;
using Backend_School.WebApi.Models.Request;
using Backend_School.WebApi.Models.Response;
using System.Collections.Generic;

namespace Backend_School.WebApi.Services.Interface
{
    public interface IPenggunaRoleService
    {
        Task<IEnumerable<PenggunaRoleResponse>> GetPenggunaRoleById(IdPenggunaRoleRequest request, CancellationToken cancellationToken = default);
        Task<IEnumerable<PenggunaRoleResponse>> CheckAddPenggunaRole(CheckPenggunaRoleRequest parameter, CancellationToken cancellationToken = default);
        Task<IEnumerable<PenggunaRoleResponse>> AddPenggunaRole(PenggunaRoleAddRequest parameter, CancellationToken cancellationToken = default);
        Task<IEnumerable<PenggunaRoleResponse>> EditPenggunaRole(PenggunaRoleUpdateRequest parameter, CancellationToken cancellationToken = default);
        Task<int> DeletePenggunaRole(long Id, CancellationToken cancellationToken = default);
    }
}
