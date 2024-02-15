namespace PrototypeWPAPI;
using Newtonsoft.Json;
using Geolocation;

public class Helpers
{
    public static string ObjectToJson(Object ob)
    {
        var json = JsonConvert.SerializeObject(ob);

        return json;
    }

    public static string DisplayDistance(Location location, Coordinate currentCoords)
    {
        Coordinate locationCoords = new Coordinate(location.Latitude, location.Longitude);

        double dist = GeoCalculator.GetDistance(locationCoords, currentCoords, 1);

        return $"Distance: {dist} miles.";
    }
}