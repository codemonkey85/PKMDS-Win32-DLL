using static PKMDS_CS.PKMDS;

namespace PKMDS_CS
{
    public class Location
    {
        private ushort locationid;
        public Location(ushort locationid) => this.locationid = locationid;
        public Location() => locationid = 0;
        public ushort LocationID
        {
            get => locationid;
            set => locationid = value;
        }
        public string LocationName
        {
            get
            {
                switch (LocationID)
                {
                    case 2000:
                        return "Day-Care Couple (Gen IV)";
                    case 30001:
                        return "Poké Transfer";
                    case 30012:
                        return "a special place (1)";
                    case 30013:
                        return "a special place (2)";
                    case 30015:
                        return "Pokémon Dream Radar";
                    case 40001:
                        return "Lovely Place";
                    case 40069:
                        return "Wi-Fi Gift";
                    case 60002:
                        return "Day-Care Couple";
                    default:
                        return GetLocationName(LocationID);
                }
            }
        }
    }
}
