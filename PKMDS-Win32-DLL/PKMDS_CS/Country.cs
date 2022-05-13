namespace PKMDS_CS
{
    public class Country
    {
        private byte countryid;
        public Country(byte countryid) => this.countryid = countryid;
        public Country() => countryid = 0;
        public byte CountryID
        {
            get => countryid;
            set => countryid = value;
        }
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
