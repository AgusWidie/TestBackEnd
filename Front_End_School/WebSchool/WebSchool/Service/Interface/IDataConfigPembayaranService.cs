using System.Threading.Tasks;
using System.Threading;
using WebSchool.Models.Admin.DataConfigPembayaran;
using WebSchool.Models;

namespace WebSchool.Service.Interface
{
    public interface IDataConfigPembayaranService
    {
        Task<GlobalObjectListResponseJson<DataConfigPembayaran>> DataConfigPembayaranById(IdConfigPembayaran model, CancellationToken cancellationToken = default);
        Task<GlobalObjectListResponseJson<DataConfigPembayaran>> DataConfigPembayaranByNama(NamaConfigPembayaran model, CancellationToken cancellationToken = default);
    }
}
