using System;
using System.Collections.Generic;
using System.Text;

namespace Common.ResultModels
{
    public interface IResult
    {
        bool Success { get; }
        string Message { get; set; }
    }
}
