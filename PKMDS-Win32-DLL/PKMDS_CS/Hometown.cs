namespace PKMDS_CS
{
    public class Hometown
    {
        private byte hometownid;
        public Hometown(byte hometownid) => this.hometownid = hometownid;
        public Hometown() => hometownid = 0;
        public byte HometownID
        {
            get => hometownid;
            set => hometownid = value;
        }
        public string HometownName
        {
            get
            {
                switch (HometownID)
                {
                    case 0:
                        return "Colosseum Bonus";
                    case 1:
                        return "Sapphire";
                    case 2:
                        return "Ruby";
                    case 3:
                        return "Emerald";
                    case 4:
                        return "FireRed";
                    case 5:
                        return "LeafGreen";
                    case 7:
                        return "HeartGold";
                    case 8:
                        return "SoulSilver";
                    case 10:
                        return "Diamond";
                    case 11:
                        return "Pearl";
                    case 12:
                        return "Platinum";
                    case 15:
                        return "Colosseum / XD";
                    case 20:
                        return "White";
                    case 21:
                        return "Black";
                    case 22:
                        return "White 2";
                    case 23:
                        return "Black 2";
                    default:
                        return string.Empty;
                }
            }
        }
    }
}
