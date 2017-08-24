using System;
using Newtonsoft.Json;

namespace Puzzle.Responses
{
    public class JsonFormatter
    {
        [JsonProperty(PropertyName = "body")]
        private Object _message;

        [JsonProperty(PropertyName = "timestamp")]
		private readonly long _timeStamp;

        public JsonFormatter()
        {
            _timeStamp = DateTime.Now.ToFileTime();
        }

        public JsonFormatter(Response response) : this()
        {
            _message = response.GetMessage();
        }
    }
}
