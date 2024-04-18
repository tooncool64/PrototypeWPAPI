using Geolocation;
using PrototypeWPAPI;

var currentCoords = new Coordinate(47.037872, -122.900696);

WikipediaApi wpApi = new WikipediaApi(currentCoords, 10, 5);

var locationList = wpApi.Locations;

foreach (var location in locationList)
{
    var response = WikimonApi.SendLocation(location);

    Console.WriteLine(Helpers.DisplayDistance(location, currentCoords));
    Console.WriteLine(response);
    Console.WriteLine(response.Content.ReadAsStringAsync().Result);
}

var receivedList = WikimonApi.ReceiveLocations(5, currentCoords);

foreach (var location in receivedList)
{
    Console.WriteLine(location.Title);
}