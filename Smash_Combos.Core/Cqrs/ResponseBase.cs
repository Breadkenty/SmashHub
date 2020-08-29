using System;
using System.Collections.Generic;
using System.Text;

namespace Smash_Combos.Core.Cqrs
{
    public abstract class ResponseBase
    {
        public ResponseStatus Status { get; set; }
    }

    public abstract class ResponseBase<T> : ResponseBase
    {
        public T Data { get; set; }
    }
}
