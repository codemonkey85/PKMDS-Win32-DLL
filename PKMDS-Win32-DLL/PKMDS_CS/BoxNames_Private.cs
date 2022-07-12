namespace PKMDS_CS;

[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode, Pack = 1)]
[Serializable]
internal class BoxNames_Private
{
    public BoxName Boxes(int slot) => slot switch
    {
        0 => BoxName01,
        1 => BoxName02,
        2 => BoxName03,
        3 => BoxName04,
        4 => BoxName05,
        5 => BoxName06,
        6 => BoxName07,
        7 => BoxName08,
        8 => BoxName09,
        9 => BoxName10,
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
    public BoxName BoxName01;
    public BoxName BoxName02;
    public BoxName BoxName03;
    public BoxName BoxName04;
    public BoxName BoxName05;
    public BoxName BoxName06;
    public BoxName BoxName07;
    public BoxName BoxName08;
    public BoxName BoxName09;
    public BoxName BoxName10;
    public BoxName BoxName11;
    public BoxName BoxName12;
    public BoxName BoxName13;
    public BoxName BoxName14;
    public BoxName BoxName15;
    public BoxName BoxName16;
    public BoxName BoxName17;
    public BoxName BoxName18;
    public BoxName BoxName19;
    public BoxName BoxName20;
    public BoxName BoxName21;
    public BoxName BoxName22;
    public BoxName BoxName23;
    public BoxName BoxName24;
}
