using Newtonsoft.Json;

namespace HelloWorldSteriods
{
    public class Joke
    {
        public string Value { get; set; }
        public  string Url { get; set; }
        [JsonProperty("icon_url")]
        public string IconUrl { get; set; }
        public string Id { get; set; }
    }
}