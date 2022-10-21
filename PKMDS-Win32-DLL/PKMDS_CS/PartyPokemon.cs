namespace PKMDS_CS;

[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
[Serializable]
public class PartyPokemon
{
    public PartyPokemon() => PokemonData = new Pokemon();
    internal void Decrypt() => DecryptPartyPokemon(this);
    private Pokemon mPokemonData = new();
    public Pokemon PokemonData
    {
        get => mPokemonData;
        set => mPokemonData = value;
    }
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 84)]
    private readonly byte[] PartyData = Array.Empty<byte>();
    public void WriteToFile(string FileName, bool encrypt = false) => WritePokemonFile(PokemonData, FileName, encrypt);
}
