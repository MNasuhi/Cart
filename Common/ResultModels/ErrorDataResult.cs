using System;
using System.Collections.Generic;
using System.Text;

namespace Common.ResultModels
{
    public class ErrorDataResult<T> : IDataResult<T>
    {
        public ErrorDataResult(string message, T data)
        {
            Success = false;
            Message = message;
            Data = data;
        }

        public bool Success { get; }

        public T Data { get; set; }

        public string Message { get; set; }
    }
}
