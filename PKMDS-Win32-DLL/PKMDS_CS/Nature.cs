using static PKMDS_CS.PKMDS;

namespace PKMDS_CS
{
    public class Nature
    {
        private byte natureid;
        public Nature(byte natureid) => this.natureid = natureid;
        public Nature() => natureid = 0;
        public byte NatureID
        {
            get => natureid;
            set => natureid = value;
        }
        public string NatureName => GetNatureName(NatureID);
    }
}
