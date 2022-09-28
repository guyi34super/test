using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elca.Sms.Api.Domain.Communication
{
    public abstract class BaseResponse
    {
        public bool Success { get; protected set; }
        public string Message { get; protected set; }
        public BaseResponse(bool success, string message)
        {
            Success = success;
            Message = message;
        }
    }
}
