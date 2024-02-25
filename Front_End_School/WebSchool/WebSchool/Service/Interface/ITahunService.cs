using System.Threading.Tasks;
using System.Threading;
using WebSchool.Models.Admin.Tahun;
using WebSchool.Models;

namespace WebSchool.Service.Interface
{
    public interface ITahunService
    {
        Task<GlobalObjectListResponseJson<Tahunn>> ListTahun(CancellationToken cancellationToken = default);
    }
}
