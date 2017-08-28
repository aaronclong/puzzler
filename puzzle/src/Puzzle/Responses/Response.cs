using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace Puzzle.Responses
{
    public interface Response
    {
        IDictionary<string, object> GetMessage();
    }
}
