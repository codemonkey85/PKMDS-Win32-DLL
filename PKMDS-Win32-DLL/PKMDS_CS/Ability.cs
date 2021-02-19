using static PKMDS_CS.PKMDS;

namespace PKMDS_CS
{
    public class Ability
    {
        private ushort abilityid;
        public Ability(ushort abilityid) => this.abilityid = abilityid;
        public Ability() => abilityid = 0;
        public ushort AbilityID
        {
            get => abilityid;
            set => abilityid = value;
        }
        public string AbilityName => GetAbilityName(AbilityID);
        public string AbilityFlavor => GetAbilityFlavor(AbilityID);
    }
}
