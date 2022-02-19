using System;
using System.Collections.Generic;
using System.Text;

namespace Common.ResultModels
{
    public class SuccessDataResult<T> : IDataResult<T>
    {
        public SuccessDataResult(string message, T data)
        {
            Success = true;
            Message = message;
            Data = data;
        }

        public bool Success { get; }

        public T Data { get; set; }

        public string Message { get; set; }
    }
}
