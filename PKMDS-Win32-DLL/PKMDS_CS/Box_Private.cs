namespace PKMDS_CS;

[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
[Serializable]
internal class Box_Private
{
    public Pokemon? Pokemon(int slot) => slot switch
    {
        00 => Pokemon01,
        01 => Pokemon02,
        02 => Pokemon03,
        03 => Pokemon04,
        04 => Pokemon05,
        05 => Pokemon06,
        06 => Pokemon07,
        07 => Pokemon08,
        08 => Pokemon09,
        09 => Pokemon10,
        10 => Pokemon11,
        11 => Pokemon12,
        12 => Pokemon13,
        13 => Pokemon14,
        14 => Pokemon15,
        15 => Pokemon16,
        16 => Pokemon17,
        17 => Pokemon18,
        18 => Pokemon19,
        19 => Pokemon20,
        20 => Pokemon21,
        21 => Pokemon22,
        22 => Pokemon23,
        23 => Pokemon24,
        24 => Pokemon25,
        25 => Pokemon26,
        26 => Pokemon27,
        27 => Pokemon28,
        28 => Pokemon29,
        29 => Pokemon30,
        _ => null,
    };
    [NonSerialized()]
    private readonly Pokemon Pokemon01 = new();
    [NonSerialized()]
    private readonly Pokemon Pokemon02 = new();
    [NonSerialized()]
    private readonly Pokemon Pokemon03 = new();
    [NonSerialized()]
    private readonly Pokemon Pokemon04 = new();
    [NonSerialized()]
    private readonly Pokemon Pokemon05 = new();
    [NonSerialized()]
    private readonly Pokemon Pokemon06 = new();
    [NonSerialized()]
    private readonly Pokemon Pokemon07 = new();
    [NonSerialized()]
    private readonly Pokemon Pokemon08 = new();
    [NonSerialized()]
    private readonly Pokemon Pokemon09 = new();
    [NonSerialized()]
    private readonly Pokemon Pokemon10 = new();
    [NonSerialized()]
    private readonly Pokemon Pokemon11 = new();
    [NonSerialized()]
    private readonly Pokemon Pokemon12 = new();
    [NonSerialized()]
    private readonly Pokemon Pokemon13 = new();
    [NonSerialized()]
    private readonly Pokemon Pokemon14 = new();
    [NonSerialized()]
    private readonly Pokemon Pokemon15 = new();
    [NonSerialized()]
    private readonly Pokemon Pokemon16 = new();
    [NonSerialized()]
    private readonly Pokemon Pokemon17 = new();
    [NonSerialized()]
    private readonly Pokemon Pokemon18 = new();
    [NonSerialized()]
    private readonly Pokemon Pokemon19 = new();
    [NonSerialized()]
    private readonly Pokemon Pokemon20 = new();
    [NonSerialized()]
    private readonly Pokemon Pokemon21 = new();
    [NonSerialized()]
    private readonly Pokemon Pokemon22 = new();
    [NonSerialized()]
    private readonly Pokemon Pokemon23 = new();
    [NonSerialized()]
    private readonly Pokemon Pokemon24 = new();
    [NonSerialized()]
    private readonly Pokemon Pokemon25 = new();
    [NonSerialized()]
    private readonly Pokemon Pokemon26 = new();
    [NonSerialized()]
    private readonly Pokemon Pokemon27 = new();
    [NonSerialized()]
    private readonly Pokemon Pokemon28 = new();
    [NonSerialized()]
    private readonly Pokemon Pokemon29 = new();
    [NonSerialized()]
    private readonly Pokemon Pokemon30 = new();
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 0x10)]
    private readonly byte[] Data = [];
    public Box_Private()
    {

    }
}
