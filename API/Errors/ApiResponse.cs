using System;

namespace API.Errors
{
    public class ApiResponse
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public ApiResponse(int statusCode, string message = null)
        {
            StatusCode = statusCode;

            //?? if this is null then execute whats to the right of the operator null colensen operator
            Message = message ?? GetDefaultMessageForStatusCode(statusCode);
        }

        private string GetDefaultMessageForStatusCode(int statusCode)
        {
            return statusCode switch
            {
                400 => "A bad request was made",
                401 => "Autherization required",
                404 => "Resource was not found",
                500 => "Error",
                _=> null
            };
        }

        
    }
}