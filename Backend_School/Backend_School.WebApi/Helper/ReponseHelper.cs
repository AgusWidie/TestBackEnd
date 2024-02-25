using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using Backend_School.WebApi.Models;

namespace Backend_School.WebApi.Helper
{
    public static class ResponseHelper<T>
    {
        public static GlobalObjectListResponse<T> Create(string message, IEnumerable<T> data)
        {
            return new()
            {
                Code = StatusCodes.Status200OK,
                Error = false,
                Message = message,
                Data = data
            };
        }

        public static GlobalObjectResponse<T> Create(string message, T data)
        {
            return new()
            {
                Code = StatusCodes.Status200OK,
                Error = false,
                Message = message,
                Data = data
            };
        }
    }

    public static class ResponseHelper
    {

        public static GlobalResponse Create(string message)
        {
            return new()
            {
                Code = StatusCodes.Status200OK,
                Error = false,
                Message = message
            };
        }

        public static GlobalResponse CreateError(int code, string message)
        {
            return new()
            {
                Code = code,
                Error = true,
                Message = message
            };
        }
        public static GlobalErrorResponse CreateError(int code, string message, string traceId = null)
        {
            return new()
            {
                Code = code,
                Error = true,
                Message = message,
                TraceId = traceId
            };
        }
    }

    
}
