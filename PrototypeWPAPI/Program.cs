﻿using PrototypeWPAPI;

int counter = 0;

var locations = WikipediaApi.GetLocations(25, 10, 47.064175, -122.857908);

foreach (var location in locations.Query.Geosearch)
{
        counter++;
        Console.WriteLine(location.Title);
        Console.WriteLine($"{Helpers.MetersToMilesRadius(location.Dist)} mi.");

        var url = new Uri($"https://en.wikipedia.org/wiki/" + $"{location.Title.Replace(" ", "_")}");

        Console.WriteLine(url);
}
Console.WriteLine(counter);