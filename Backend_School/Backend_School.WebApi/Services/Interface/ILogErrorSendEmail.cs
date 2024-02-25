using System.Threading.Tasks;
using Backend_School.WebApi.Models.Request;
using Backend_School.WebApi.Models.Response;
using System.Collections.Generic;
using System.Threading;


namespace Backend_School.WebApi.Services.Interface
{
    public interface ILogErrorSendEmail
    {
        Task<string> ErrorSendEmail(LogErrorRequest parameter, CancellationToken cancellationToken = default);
    }
}
