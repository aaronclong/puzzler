using System;
using Newtonsoft.Json;

namespace Puzzle.Responses
{
    public class JsonFormatter
    {
        private Object _message;

        public JsonFormatter(Response response)
        {
            _message = response.GetMessage();
        }

        public DateTime TimeStamp()
        {
            return DateTime.Now;
        }

        public Object Body()
        {
            return _message;
        }
    }
}
