namespace PrototypeWPAPI;
using Geolocation;
using Newtonsoft.Json;

public class WikipediaApi
{
    public static Coordinate Coords;

    public List<Location> Locations;

    public int RequestLimit;

    public int Radius;

    public WikipediaApi(Coordinate coords, int requestLimit, int radius)
    {
        Coords = coords;
        RequestLimit = requestLimit;
        Radius = radius;
        
        GetLocations();
    }

    private void GetLocations()
    {
        var formRadius = Radius * 1000;
        var coords = $"{Convert.ToString(Coords.Latitude)}" + "%7C" + $"{Convert.ToString(Coords.Longitude)}";

        if (formRadius > 10000)
        {
            Console.WriteLine("Warning: Radius cannot be larger than Ten Kilometers.");
        }

        using (var client = new HttpClient())
        {
            var endpoint =
                new Uri(
                    $"https://en.wikipedia.org/w/api.php?action=query&gscoord={coords}&gslimit={RequestLimit}&gsradius={formRadius}&list=geosearch&format=json");

            var result = client.GetAsync(endpoint).Result;

            var json = result.Content.ReadAsStringAsync().Result;

            var locations = JsonConvert.DeserializeObject<ApiLocations.Locations>(json)!;

            var locationList = LocationConverter(locations);

            Locations = locationList;
        }
    }

    private List<Location> LocationConverter(ApiLocations.Locations locations)
    {
        var locationList = new List<Location>();

        foreach (var location in locations.Query.Geosearch)
        {
            var url = $"https://en.wikipedia.org/wiki/" + $"{location.Title.Replace(" ", "_")}";

            var loc = new Location
            {
                Id = location.Pageid,
                Latitude = location.Lat,
                Longitude = location.Lon,
                Title = location.Title,
                Url = url
            };

            locationList.Add(loc);
        }

        return locationList;
    }
}