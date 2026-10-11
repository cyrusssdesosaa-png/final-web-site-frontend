namespace WallyWombatsPublic_MVC.Models;

public readonly record struct MapCoord(double Lat, double Lng);

public static class LocationMapPins
{
    public static MapCoord? Coords(string? slug) => (slug ?? "").Trim().ToLowerInvariant() switch
    {
        "las-vegas" => new MapCoord(36.21771, -115.24484),
        "henderson" => new MapCoord(36.06423, -115.03921),
        "bullhead-city" => new MapCoord(35.11123, -114.59834),
        _ => null
    };
}
