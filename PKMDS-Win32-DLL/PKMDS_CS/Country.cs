namespace PKMDS_CS;

public class Country
{
    public Country(byte countryid) => CountryID = countryid;
    public Country() => CountryID = 0;
    public byte CountryID { get; set; }
    public string CountryName => CountryID switch
    {
        1 => "JA",
        2 => "ENG/UK/AUS",
        3 => "FR",
        4 => "ITA",
        5 => "DE",
        7 => "SPA",
        8 => "SOK",
        _ => string.Empty,
    };
}
