using Microsoft.Extensions.Configuration;
using System.Text.Json;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using WebSchool.Configuration;
using Microsoft.AspNetCore.Http;

namespace WebSchool.Service
{
    public class LoginPenggunaService : ILoginPenggunaService
    {
        private readonly ApiConfiguration _apiConfig;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private ISession _session => _httpContextAccessor.HttpContext.Session;
        public LoginPenggunaService(IConfiguration configuration, IHttpContextAccessor httpContextAccessor)
        {
            _apiConfig = configuration.GetSection(nameof(ApiConfiguration)).Get<ApiConfiguration>();
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<string> LoginPengguna(CancellationToken cancellationToken)
        {
            var userName = _session.GetString("UserName"); 
            return userName;
        }
    }
}
