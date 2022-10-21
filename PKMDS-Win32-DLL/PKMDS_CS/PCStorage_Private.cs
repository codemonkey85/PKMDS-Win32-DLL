namespace PKMDS_CS;

[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
[Serializable]
internal class PCStorage_Private
{
    public Box_Private? Box(int box) => box switch
    {
        00 => Box01,
        01 => Box02,
        02 => Box03,
        03 => Box04,
        04 => Box05,
        05 => Box06,
        06 => Box07,
        07 => Box08,
        08 => Box09,
        09 => Box10,
        10 => Box11,
        11 => Box12,
        12 => Box13,
        13 => Box14,
        14 => Box15,
        15 => Box16,
        16 => Box17,
        17 => Box18,
        18 => Box19,
        19 => Box20,
        20 => Box21,
        21 => Box22,
        22 => Box23,
        23 => Box24,
        _ => null,
    };
    [NonSerialized()]
    private readonly Box_Private Box01 = new();
    [NonSerialized()]
    private readonly Box_Private Box02 = new();
    [NonSerialized()]
    private readonly Box_Private Box03 = new();
    [NonSerialized()]
    private readonly Box_Private Box04 = new();
    [NonSerialized()]
    private readonly Box_Private Box05 = new();
    [NonSerialized()]
    private readonly Box_Private Box06 = new();
    [NonSerialized()]
    private readonly Box_Private Box07 = new();
    [NonSerialized()]
    private readonly Box_Private Box08 = new();
    [NonSerialized()]
    private readonly Box_Private Box09 = new();
    [NonSerialized()]
    private readonly Box_Private Box10 = new();
    [NonSerialized()]
    private readonly Box_Private Box11 = new();
    [NonSerialized()]
    private readonly Box_Private Box12 = new();
    [NonSerialized()]
    private readonly Box_Private Box13 = new();
    [NonSerialized()]
    private readonly Box_Private Box14 = new();
    [NonSerialized()]
    private readonly Box_Private Box15 = new();
    [NonSerialized()]
    private readonly Box_Private Box16 = new();
    [NonSerialized()]
    private readonly Box_Private Box17 = new();
    [NonSerialized()]
    private readonly Box_Private Box18 = new();
    [NonSerialized()]
    private readonly Box_Private Box19 = new();
    [NonSerialized()]
    private readonly Box_Private Box20 = new();
    [NonSerialized()]
    private readonly Box_Private Box21 = new();
    [NonSerialized()]
    private readonly Box_Private Box22 = new();
    [NonSerialized()]
    private readonly Box_Private Box23 = new();
    [NonSerialized()]
    private readonly Box_Private Box24 = new();
    public PCStorage_Private()
    {

    }
}
