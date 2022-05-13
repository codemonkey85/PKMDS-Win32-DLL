using static PKMDS_CS.PKMDS;

namespace PKMDS_CS
{
    public class Ability
    {
        public Ability(ushort abilityid) => AbilityID = abilityid;
        public Ability() => AbilityID = 0;
        public ushort AbilityID { get; set; }
        public string AbilityName => GetAbilityName(AbilityID);
        public string AbilityFlavor => GetAbilityFlavor(AbilityID);
    }
}
