using Microsoft.Extensions.Configuration;
using System.Text.Json;
using System.IO;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using WebSchool.Configuration;
using WebSchool.Models;


namespace WebSchool.Service
{
    public class LoginService : ILoginService
    {
        private readonly ApiConfiguration _apiConfig;
        public LoginService(IConfiguration configuration)
        {
            _apiConfig = configuration.GetSection(nameof(ApiConfiguration)).Get<ApiConfiguration>();
        }

        public async Task<GlobalResponseJson> ConnectDB(CancellationToken cancellationToken)
        {

            var httpWebRequest = (HttpWebRequest)WebRequest.Create(_apiConfig.BaseUrl + _apiConfig.UriConnectDB);
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";

            ApiKeyModel ApiKeyModel = new ApiKeyModel();
            ApiKeyModel.ApiKey = _apiConfig.ApiKey;

            var options = new JsonSerializerOptions()
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };
            var json = JsonSerializer.Serialize(ApiKeyModel, options);

            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                streamWriter.Write(json);
                streamWriter.Close();
                streamWriter.Dispose();
            }

            var response = httpWebRequest.GetResponse();
            var stream = response.GetResponseStream();
            var sr = new StreamReader(stream);
            var content = sr.ReadToEnd();

            sr.Close();
            sr.Dispose();

            GlobalResponseJson res = JsonSerializer.Deserialize<GlobalResponseJson>(content, options);
            return res;
        }

        public async Task<GlobalObjectListResponseJson<Login>> LoginPengguna(LoginModel model, CancellationToken cancellationToken)
        {

            var httpWebRequest = (HttpWebRequest)WebRequest.Create(_apiConfig.BaseUrl + _apiConfig.UriLogin);
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";
            model.ApiKey = _apiConfig.ApiKey;

            var options = new JsonSerializerOptions()
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };
            var json = JsonSerializer.Serialize(model, options);

            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                streamWriter.Write(json);
                streamWriter.Close();
                streamWriter.Dispose();
            }

            var response = httpWebRequest.GetResponse();
            var stream = response.GetResponseStream();
            var sr = new StreamReader(stream);
            var content = sr.ReadToEnd();

            sr.Close();
            sr.Dispose();

            GlobalObjectListResponseJson<Login> res = JsonSerializer.Deserialize<GlobalObjectListResponseJson<Login>>(content, options);
            return res;
        }

    }
}
