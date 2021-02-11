using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BaggageTransfer.Models
{
    public class ReturnObject<T>
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public ApiResult Result { get; set; }
        public T Data { get; set; }
        public Exception Error { get; set; }
    }
}