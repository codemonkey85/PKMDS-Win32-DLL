using static PKMDS_CS.PKMDS;

namespace PKMDS_CS;

public class Nature
{
    public Nature(byte natureid) => NatureID = natureid;
    public Nature() => NatureID = 0;
    public byte NatureID { get; set; }
    public string NatureName => GetNatureName(NatureID);
}
