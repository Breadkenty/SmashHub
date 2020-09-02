using System;
using System.Collections.Generic;
using System.Text;

namespace Smash_Combos.Core.Cqrs
{
    public enum ResponseStatus
    {
        Ok,             // Everything went as expected, the request was fulfilled
        NotFound,       // The resource requested was not found
        BadRequest,     // The request contained errors/faulty data
        NotAuthorized,  // The sender was not authorized for the request
        Error           // Something went wrong internally
    }
}
