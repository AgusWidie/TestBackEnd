using System.Threading;
using System.Threading.Tasks;
using Backend_School.WebApi.Models.Request;
using Backend_School.WebApi.Models.Response;
using System.Collections.Generic;

namespace Backend_School.WebApi.Services.Interface
{
    public interface IMenuPenggunaRoleService
    {
        Task<IEnumerable<MenuResponse>> GetMenuPengguna(NamaPenggunaRequest parameter, CancellationToken cancellationToken = default);
        Task<IEnumerable<MenuHeaderResponse>> GetMenuHeaderPengguna(IdMenuPenggunaRequest IdPengguna, CancellationToken cancellationToken = default);
    }
}
