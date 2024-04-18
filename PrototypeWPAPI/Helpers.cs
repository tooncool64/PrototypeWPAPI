namespace PrototypeWPAPI;
using Geolocation;

public static class Helpers
{
    public static string DisplayDistance(Location location, Coordinate currentCoords)
    {
        Coordinate locationCoords = new Coordinate(location.Latitude, location.Longitude);

        double dist = GeoCalculator.GetDistance(locationCoords, currentCoords);

        return $"Distance: {dist} miles.";
    }
}