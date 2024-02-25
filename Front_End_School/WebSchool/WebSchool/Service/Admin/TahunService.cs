using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System.IO;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using System.Threading;
using WebSchool.Configuration;
using WebSchool.Models;
using WebSchool.Models.Admin.Tahun;
using System.Linq;
using WebSchool.Service.Interface;

namespace WebSchool.Service
{
    public class TahunService : ITahunService
    {
        private readonly ApiConfiguration _apiConfig;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private ISession _session => _httpContextAccessor.HttpContext.Session;

        public TahunService(IConfiguration configuration, IHttpContextAccessor httpContextAccessor)
        {
            _apiConfig = configuration.GetSection(nameof(ApiConfiguration)).Get<ApiConfiguration>();
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<GlobalObjectListResponseJson<Tahunn>> ListTahun(CancellationToken cancellationToken)
        {
            string Token = "";
            var httpWebRequestCheckToken = (HttpWebRequest)WebRequest.Create(_apiConfig.BaseUrl + _apiConfig.UriCheckToken);
            httpWebRequestCheckToken.ContentType = "application/json";
            httpWebRequestCheckToken.Method = "POST";

            CheckTokenModel modelApiKey = new CheckTokenModel();
            modelApiKey.ApiKey = _apiConfig.ApiKey;
            //modelApiKey.NamaPengguna = _httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier);
            modelApiKey.NamaPengguna = _session.GetString("UserName");
            var options = new JsonSerializerOptions()
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };
            var jsonApiKey = JsonSerializer.Serialize(modelApiKey, options);
            using (var streamWriter = new StreamWriter(httpWebRequestCheckToken.GetRequestStream()))
            {
                streamWriter.Write(jsonApiKey);
                streamWriter.Close();
                streamWriter.Dispose();
            }

            var responseCheckToken = httpWebRequestCheckToken.GetResponse();
            var streamCheckToken = responseCheckToken.GetResponseStream();
            var srCheckToken = new StreamReader(streamCheckToken);
            var contentCheckToken = srCheckToken.ReadToEnd();

            GlobalObjectListResponseJson<TokenResponse> resDataToken = JsonSerializer.Deserialize<GlobalObjectListResponseJson<TokenResponse>>(contentCheckToken, options);
            if (resDataToken.Data.Any())
            {
                foreach (var data in resDataToken.Data)
                {
                    Token = data.Token;
                }
            }
            else
            {
                string jsonString =
                                    @"{
                                      ""code"": 401,
                                      ""error"": true,
                                      ""message"": ""Unauthorization"",
                                      ""data"": null
                                    }";
                GlobalObjectListResponseJson<Tahunn> resUnauthorization = JsonSerializer.Deserialize<GlobalObjectListResponseJson<Tahunn>>(jsonString, options);
                return resUnauthorization;
            }

            var httpWebRequest = (HttpWebRequest)WebRequest.Create(_apiConfig.BaseUrl + _apiConfig.UriGetTahun);
            httpWebRequest.Headers.Add("Authorization", "Bearer " + Token + "");
            httpWebRequest.Headers.Add("Strict-Transport-Security", "max-age=31536000");
            httpWebRequest.Headers.Add("X-Content-Type-Options", "nosniff");
            httpWebRequest.Headers.Add("X-Xss-Protection", "1; mode=block");
            httpWebRequest.Headers.Add("X-Frame-Options", "SAMEORIGIN");
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "GET";
            var response = httpWebRequest.GetResponse();
            var stream = response.GetResponseStream();
            var sr = new StreamReader(stream);
            var content = sr.ReadToEnd();

            srCheckToken.Close();
            srCheckToken.Dispose();
            sr.Close();
            sr.Dispose();

            GlobalObjectListResponseJson<Tahunn> resData = JsonSerializer.Deserialize<GlobalObjectListResponseJson<Tahunn>>(content, options);
            return resData;
        }
    }
}
