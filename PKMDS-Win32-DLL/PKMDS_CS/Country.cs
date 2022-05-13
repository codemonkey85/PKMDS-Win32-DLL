namespace PKMDS_CS
{
    public class Country
    {
        public Country(byte countryid) => CountryID = countryid;
        public Country() => CountryID = 0;
        public byte CountryID { get; set; }
        public string CountryName
        {
            get
            {
                switch (CountryID)
                {
                    case 1:
                        return "JA";
                    case 2:
                        return "ENG/UK/AUS";
                    case 3:
                        return "FR";
                    case 4:
                        return "ITA";
                    case 5:
                        return "DE";
                    case 7:
                        return "SPA";
                    case 8:
                        return "SOK";
                    default:
                        return string.Empty;
                }
            }
        }
    }
}
