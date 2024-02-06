namespace PrototypeWPAPI
{
    using Newtonsoft.Json;

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

    public class WikipediaApi
    {
        public static Locations GetLocations(int limit, int kmRad, double lat, double lon)
        {
            var gsradius = kmRad * 1000;
            var coords = $"{Convert.ToString(lat)}" + "%7C" + $"{Convert.ToString(lon)}";

            if (gsradius > 10000)
            {
                throw new Exception("kmRad cannot be larger then 10.");
            }

            using (var client = new HttpClient())
            {
                var endpoint = new Uri($"https://en.wikipedia.org/w/api.php?action=query&gscoord={coords}&gslimit={limit}&gsradius={gsradius}&list=geosearch&format=json");

                var result = client.GetAsync(endpoint).Result;

                var json = result.Content.ReadAsStringAsync().Result;

                Locations locations = JsonConvert.DeserializeObject<Locations>(json);

                return locations;
            }
        }
    }
}