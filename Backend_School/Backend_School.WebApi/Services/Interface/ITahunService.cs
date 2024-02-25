using Backend_School.WebApi.Models.Response;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;

namespace Backend_School.WebApi.Services.Interface
{
    public interface ITahunService
    {
        Task<IEnumerable<TahunResponse>> GetTahun(CancellationToken cancellationToken = default);
    }
}
