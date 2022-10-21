namespace PKMDS_CS;

[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode, Pack = 1)]
[Serializable]
internal class BoxNames_Private
{
    public BoxName? Boxes(int slot) => slot switch
    {
        00 => BoxName01,
        01 => BoxName02,
        02 => BoxName03,
        03 => BoxName04,
        04 => BoxName05,
        05 => BoxName06,
        06 => BoxName07,
        07 => BoxName08,
        08 => BoxName09,
        09 => BoxName10,
        10 => BoxName11,
        11 => BoxName12,
        12 => BoxName13,
        13 => BoxName14,
        14 => BoxName15,
        15 => BoxName16,
        16 => BoxName17,
        17 => BoxName18,
        18 => BoxName19,
        19 => BoxName20,
        20 => BoxName21,
        21 => BoxName22,
        22 => BoxName23,
        23 => BoxName24,
        _ => null,
    };
    public BoxName BoxName01 = new();
    public BoxName BoxName02 = new();
    public BoxName BoxName03 = new();
    public BoxName BoxName04 = new();
    public BoxName BoxName05 = new();
    public BoxName BoxName06 = new();
    public BoxName BoxName07 = new();
    public BoxName BoxName08 = new();
    public BoxName BoxName09 = new();
    public BoxName BoxName10 = new();
    public BoxName BoxName11 = new();
    public BoxName BoxName12 = new();
    public BoxName BoxName13 = new();
    public BoxName BoxName14 = new();
    public BoxName BoxName15 = new();
    public BoxName BoxName16 = new();
    public BoxName BoxName17 = new();
    public BoxName BoxName18 = new();
    public BoxName BoxName19 = new();
    public BoxName BoxName20 = new();
    public BoxName BoxName21 = new();
    public BoxName BoxName22 = new();
    public BoxName BoxName23 = new();
    public BoxName BoxName24 = new();
}
