using System;
using System.Collections.Generic;
using System.Text;

namespace Common.ResultModels
{
    public class ErrorResult : IResult
    {
        public ErrorResult(string message)
        {
            Success = false;
            Message = message;
        }

        public bool Success { get; }
        public string Message { get; set; }
    }
}
