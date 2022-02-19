using System;
using System.Collections.Generic;
using System.Text;

namespace Common.ResultModels
{
    public interface IDataResult<T> : IResult
    {
        T Data { get; set; }
    }
}
