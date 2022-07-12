using System;
using System.Runtime.InteropServices;
using static PKMDS_CS.PKMDS;

namespace PKMDS_CS;

[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
[Serializable]
public class PartyPokemon
{
    public PartyPokemon() => PokemonData = new Pokemon();
    internal void Decrypt() => DecryptPartyPokemon(this);
    private Pokemon mPokemonData;
    public Pokemon PokemonData
    {
        get => mPokemonData;
        set => mPokemonData = value;
    }
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 84)]
    private readonly byte[] PartyData;
    public void WriteToFile(string FileName, bool encrypt = false) => WritePokemonFile(PokemonData, FileName, encrypt);
}
