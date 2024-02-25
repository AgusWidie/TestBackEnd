using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using System.Collections.Generic;
using static System.Net.Mime.MediaTypeNames;
using System.Text;
using System.Text.Json.Serialization;

namespace WebSchool.Models
{

    public class GlobalResponseJson
    {
        [JsonPropertyName("code")]
        public int code { get; set; }
        [JsonPropertyName("error")]
        public bool error { get; set; }
        [JsonPropertyName("message")]
        public string message { get; set; }
    }

    public class GlobalErrorResponseJson
    {
        [JsonPropertyName("code")]
        public int Code { get; set; }
        [JsonPropertyName("error")]
        public bool Error { get; set; }
        [JsonPropertyName("message")]
        public string Message { get; set; }
        [JsonPropertyName("traceId")]
        public string TraceId { get; set; }
    }

    public class GlobalObjectResponseJson
    {
        public int Code { get; set; }
        public bool Error { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }
    }

    public class GlobalObjectListResponseJson<T>
    {
        [JsonPropertyName("code")]
        public int Code { get; set; }
        [JsonPropertyName("error")]
        public bool Error { get; set; }
        [JsonPropertyName("message")]
        public string Message { get; set; }
        [JsonPropertyName("data")]
        public IEnumerable<T> Data { get; set; }
    }

    public class GlobalObjectResponseJson<T>
    {
        [JsonPropertyName("code")]
        public int Code { get; set; }
        [JsonPropertyName("error")]
        public bool Error { get; set; }
        [JsonPropertyName("message")]
        public string Message { get; set; }
        [JsonPropertyName("data")]
        public T Data { get; set; }
    }
}
