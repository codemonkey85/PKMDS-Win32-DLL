namespace PKMDS_CS;

[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
[Serializable]
internal class Party_Private
{
    public PartyPokemon? Pokemon(int slot) => slot switch
    {
        0 => PPKM01,
        1 => PPKM02,
        2 => PPKM03,
        3 => PPKM04,
        4 => PPKM05,
        5 => PPKM06,
        _ => null,
    };
    public uint Size;
    private readonly uint buffer;
    [NonSerialized()]
    private readonly PartyPokemon PPKM01 = new();
    [NonSerialized()]
    private readonly PartyPokemon PPKM02 = new();
    [NonSerialized()]
    private readonly PartyPokemon PPKM03 = new();
    [NonSerialized()]
    private readonly PartyPokemon PPKM04 = new();
    [NonSerialized()]
    private readonly PartyPokemon PPKM05 = new();
    [NonSerialized()]
    private readonly PartyPokemon PPKM06 = new();
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 0x0C)]
    private readonly byte[] Data = Array.Empty<byte>();
    public Party_Private()
    {

    }
}
