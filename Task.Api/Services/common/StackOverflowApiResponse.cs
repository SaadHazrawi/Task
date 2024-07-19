using Core.common;
using Newtonsoft.Json;

namespace Services.common
{
    public class StackOverflowApiResponse
    {
        [JsonProperty("items")]
        public List<StackOverflowPost> Items { get; set; }
    }
}
