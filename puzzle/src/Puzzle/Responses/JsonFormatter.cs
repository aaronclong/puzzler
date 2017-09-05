using System;
using Newtonsoft.Json;
using Puzzle.JsonModels;

namespace Puzzle.Responses
{
    public class JsonFormatter
    {
        [JsonExtensionData]
        [JsonProperty(PropertyName = "body")]
        private IJsonModel _message;

        [JsonProperty(PropertyName = "timestamp")]
		private readonly long _timeStamp;

        public JsonFormatter()
        {
            _timeStamp = DateTime.Now.ToFileTime();
        }

        public JsonFormatter(IJsonModel model) : this()
		{
            _message = model;
		}
    }
}
