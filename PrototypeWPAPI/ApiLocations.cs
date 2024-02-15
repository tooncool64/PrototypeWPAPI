namespace PrototypeWPAPI;
using Newtonsoft.Json;

public class ApiLocations
{
    public partial class Locations
    {
        [JsonProperty("batchcomplete")]
        public string Batchcomplete { get; set; }

        [JsonProperty("query")]
        public Query Query { get; set; }
    }

    public partial class Query
    {
        [JsonProperty("geosearch")]
        public Geosearch[] Geosearch { get; set; }
    }

    public partial class Geosearch
    {
        [JsonProperty("pageid")]
        public long Pageid { get; set; }

        [JsonProperty("ns")]
        public long Ns { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("lat")]
        public double Lat { get; set; }

        [JsonProperty("lon")]
        public double Lon { get; set; }

        [JsonProperty("dist")]
        public double Dist { get; set; }

        [JsonProperty("primary")]
        public string Primary { get; set; }
    }
}