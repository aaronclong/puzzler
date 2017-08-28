using System;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using Puzzle.RequestModels;

namespace Puzzle.Responses
{
    public class JsonFormatter
    {
        [JsonExtensionData]
        //[JsonProperty(PropertyName = "body")]
        private IDictionary<string, object> _message;

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

        public JsonFormatter(string message) : this()
        {
            _message = new Dictionary<string, object>
            {
                { "status", message }
            };
        }
    }
}
