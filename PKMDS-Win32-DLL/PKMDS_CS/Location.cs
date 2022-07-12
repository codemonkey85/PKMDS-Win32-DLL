namespace PKMDS_CS;

public class Location
{
    public Location(ushort locationid) => LocationID = locationid;
    public Location() => LocationID = 0;
    public ushort LocationID { get; set; }
    public string LocationName => LocationID switch
    {
        02000 => "Day-Care Couple (Gen IV)",
        30001 => "Poké Transfer",
        30012 => "a special place (1)",
        30013 => "a special place (2)",
        30015 => "Pokémon Dream Radar",
        40001 => "Lovely Place",
        40069 => "Wi-Fi Gift",
        60002 => "Day-Care Couple",
        _ => GetLocationName(LocationID),
    };
}
