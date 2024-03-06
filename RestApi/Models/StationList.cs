namespace RestApi.Models;

public class StationList
{
    public StationInformation[]? items;

    public int Length { get; internal set; }
}