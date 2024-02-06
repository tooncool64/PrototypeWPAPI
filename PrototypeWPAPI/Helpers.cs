namespace PrototypeWPAPI;

public class Helpers
{
    public static double MetersToMilesRadius(double meters)
    {
        var miles = meters * 0.00062137;

        return Math.Round(miles, 1, MidpointRounding.AwayFromZero);
    }
}