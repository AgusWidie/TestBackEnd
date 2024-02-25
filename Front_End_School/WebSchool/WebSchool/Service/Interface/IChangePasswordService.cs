using System.Threading;
using System.Threading.Tasks;
using WebSchool.Models;

namespace WebSchool.Service.Interface
{
    public interface IChangePasswordService
    {
        Task<GlobalResponseJson> GantiPassword(ChangePassword model, CancellationToken cancellationToken = default);
    }
}
