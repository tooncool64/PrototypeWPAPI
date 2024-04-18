namespace PrototypeWPAPI;
using Newtonsoft.Json;
using Geolocation;

public class WikimonApi
{
    
    public static HttpResponseMessage SendLocation(Location location)
    {
        var jsonString = $$$"""{"id":{"0":{{{location.Id}}}},"longitude":{"0":{{{location.Longitude}}}},"latitude":{"0":{{{location.Latitude}}}},"title":{"0":"{{{location.Title}}}"},"likes":{"0":"{{{location.Likes}}}"},"url":{"0":"{{{location.Url}}}"}}""";

        using (var client = new HttpClient())
        {
            var apiUrl = new Uri($"https://lnqe7m0ysg.execute-api.us-east-1.amazonaws.com/Main/UploadDat?Hello={jsonString}");

            var result = client.GetAsync(apiUrl).Result;

            return result;
        }
    }
    
    public static Location[] ReceiveLocations(int radius, Coordinate coords)
    {
        using (var client = new HttpClient())
        {
            var endpoint = new Uri($"https://lnqe7m0ysg.execute-api.us-east-1.amazonaws.com/Main/RetrieveDat?Rad={radius}&Lat={coords.Latitude}&Long={coords.Longitude}");
                
            var result = client.GetAsync(endpoint).Result;
                
            var json = result.Content.ReadAsStringAsync().Result;
                
            var locations = JsonConvert.DeserializeObject<Location[]>(json)!;

            return locations;
        }
    }
}