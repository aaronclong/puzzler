using System;
using Microsoft.AspNetCore.Mvc;

namespace Puzzle.Responses
{
    public interface Response
    {
        Object GetMessage();
    }
}
