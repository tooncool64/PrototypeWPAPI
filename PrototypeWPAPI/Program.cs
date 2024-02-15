using Geolocation;
using PrototypeWPAPI;

Coordinate currentCoords = new Coordinate(47.064175, -122.85790);

var locations = WikipediaApi.GetLocations(5, 10, currentCoords);

var locationList = WikipediaApi.LocationConverter(locations);

foreach (var location in locationList)
{
    var json = Helpers.ObjectToJson(location);

    var response = WikipediaApi.SendJson(json);

    Console.WriteLine(Helpers.DisplayDistance(location, currentCoords));
    Console.WriteLine(response);
    Console.WriteLine(response.Content.ReadAsStringAsync().Result);
}