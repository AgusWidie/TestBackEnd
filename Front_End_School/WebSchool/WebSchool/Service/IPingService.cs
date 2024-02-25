using System.Threading.Tasks;
using System.Threading;
using WebSchool.Models;

namespace WebSchool.Service
{
    public interface IPingService
    {
        Task<GlobalResponseJson> PingServer(CancellationToken cancellationToken = default);
    }
}
