using static PKMDS_CS.PKMDS;

namespace PKMDS_CS
{
    public class Species
    {
        public Species(ushort speciesid) => SpeciesID = speciesid;
        public Species() => SpeciesID = 0;
        public ushort SpeciesID { get; set; }
        public string SpeciesName => GetPKMName(SpeciesID);
    }
}
