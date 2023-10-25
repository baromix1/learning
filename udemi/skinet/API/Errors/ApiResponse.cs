using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SQLitePCL;

namespace API.Errors
{
    public class ApiResponse
    {
        public ApiResponse(int statusCode, string message=null)
        {
            StatusCode=statusCode;
            Message=message ?? GetDefaultMessageForStatusCode(statusCode);
        }

        private string GetDefaultMessageForStatusCode( int statusCode)
        {
            return statusCode switch{
                400=>"A bad request",
                401=>"you are not authorized",
                404=>"not found a resource",
                500=>"Error",
                _=>null
            };
        }

        public int StatusCode { get; set; }
        public string Message { get; set; }
    }
}