using Geolocation;

namespace PrototypeWPAPI;
using Newtonsoft.Json;
    
 public class WikipediaApi
 {
        public static ApiLocations.Locations GetLocations(int limit, int kmRad, Coordinate currentCoords)
        {
            var gsradius = kmRad * 1000;
            var coords = $"{Convert.ToString(currentCoords.Latitude)}" + "%7C" + $"{Convert.ToString(currentCoords.Longitude)}";

            if (gsradius > 10000)
            {
                throw new Exception("kmRad cannot be larger then 10.");
            }

            using (var client = new HttpClient())
            {
                var endpoint = new Uri($"https://en.wikipedia.org/w/api.php?action=query&gscoord={coords}&gslimit={limit}&gsradius={gsradius}&list=geosearch&format=json");

                var result = client.GetAsync(endpoint).Result;

                var json = result.Content.ReadAsStringAsync().Result;

                ApiLocations.Locations locations = JsonConvert.DeserializeObject<ApiLocations.Locations>(json);

                return locations;
            }
        }

        public static HttpResponseMessage SendJson(string json)
        {
            using (var client = new HttpClient())
            {
                var apiUrl = new Uri($"https://lnqe7m0ysg.execute-api.us-east-1.amazonaws.com/Main/RoundTrip?Hello={json}");

                var result = client.GetAsync(apiUrl).Result;

                return result;
            }
        }

        public static List<Location> LocationConverter(ApiLocations.Locations locations)
        {
            List<Location> locationList = new List<Location>();
            
            foreach (var location in locations.Query.Geosearch)
            {
                var url = $"https://en.wikipedia.org/wiki/" + $"{location.Title.Replace(" ", "_")}";
                
                Location loc = new Location();
                loc.Id = location.Pageid;
                loc.Latitude = location.Lat;
                loc.Longitude = location.Lon;
                loc.Title = location.Title;
                loc.Url = url;
                
                locationList.Add(loc);
            }
            
            return locationList;
        }
 }