using Microsoft.Extensions.Configuration;
using System.IO;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using System.Threading;
using WebSchool.Configuration;
using WebSchool.Models;

namespace WebSchool.Service
{
    public class PingService : IPingService
    {
        private readonly ApiConfiguration _apiConfig;
        public PingService(IConfiguration configuration)
        {
            _apiConfig = configuration.GetSection(nameof(ApiConfiguration)).Get<ApiConfiguration>();
        }

        public async Task<GlobalResponseJson> PingServer(CancellationToken cancellationToken)
        {

            var httpWebRequest = (HttpWebRequest)WebRequest.Create(_apiConfig.BaseUrl + _apiConfig.UriPingServer);
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
    }
}
