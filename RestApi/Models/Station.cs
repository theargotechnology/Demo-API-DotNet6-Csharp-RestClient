namespace RestApi.Models;

public class Station
{
    public string Name { get; }
    
    public string Lat { get; }

    public Station(
        string name,
        string lat)
    {
        Name = name;
        Lat = lat;
    }
}