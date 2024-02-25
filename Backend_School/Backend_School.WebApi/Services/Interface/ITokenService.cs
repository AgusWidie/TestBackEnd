using System.Threading;
using System.Threading.Tasks;
using Backend_School.WebApi.Models.Request;
using Backend_School.WebApi.Models.Response;
using System.Collections.Generic;

namespace Backend_School.WebApi.Services.Interface
{
    public interface ITokenService
    {
        Task<IEnumerable<TokenResponse>> AddToken(TokenAddRequest parameter, CancellationToken cancellationToken = default);
        Task<IEnumerable<CheckTokenResponse>> GetCheckToken(CheckTokenRequest parameter, CancellationToken cancellationToken = default);
    }
}
