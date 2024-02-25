using Backend_School.WebApi.Models.Request;
using Backend_School.WebApi.Models.Response;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using Backend_School.WebApi.Models;

namespace Backend_School.WebApi.Services.Interface
{
    public interface IChangePasswordService
    {
        Task<IEnumerable<PenggunaResponse>> GantiPassword(ChangePasswordRequest parameter, CancellationToken cancellationToken = default);
    }
}
