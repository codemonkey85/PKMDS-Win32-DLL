using static PKMDS_CS.PKMDS;

namespace PKMDS_CS
{
    public class Species
    {
        private ushort speciesid;
        public Species(ushort speciesid) => this.speciesid = speciesid;
        public Species() => speciesid = 0;
        public ushort SpeciesID
        {
            get => speciesid;
            set => speciesid = value;
        }
        public string SpeciesName => GetPKMName(SpeciesID);
    }
}
