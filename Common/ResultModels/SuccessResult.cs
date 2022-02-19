using System;
using System.Collections.Generic;
using System.Text;

namespace Common.ResultModels
{
    public class SuccessResult : IResult
    {
        public SuccessResult(string message)
        {
            Success = true;
            Message = message;
        }

        public bool Success { get; }
        public string Message { get; set; }
    }
}
