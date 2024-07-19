using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.common
{
    public class ErrorResponse
    {
        public ErrorResponse(int statusCode,string message = null)
        {
            Message = message;
            StatusCode = statusCode;
        }
        public string Message { get; set; }
        public int StatusCode { get; }
    }
}
