using System;
using System.Runtime.InteropServices;

namespace PKMDS_CS
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    [Serializable]
    internal class Party_Private
    {
        public PartyPokemon Pokemon(int slot)
        {
            switch (slot)
            {
                case 0:
                    return PPKM01;
                case 1:
                    return PPKM02;
                case 2:
                    return PPKM03;
                case 3:
                    return PPKM04;
                case 4:
                    return PPKM05;
                case 5:
                    return PPKM06;
                default:
                    return null;
            }
        }
        public uint Size;
        private readonly uint buffer;
        [NonSerialized()]
        private readonly PartyPokemon PPKM01 = new PartyPokemon();
        [NonSerialized()]
        private readonly PartyPokemon PPKM02 = new PartyPokemon();
        [NonSerialized()]
        private readonly PartyPokemon PPKM03 = new PartyPokemon();
        [NonSerialized()]
        private readonly PartyPokemon PPKM04 = new PartyPokemon();
        [NonSerialized()]
        private readonly PartyPokemon PPKM05 = new PartyPokemon();
        [NonSerialized()]
        private readonly PartyPokemon PPKM06 = new PartyPokemon();
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 0x0C)]
        private readonly byte[] Data;
        public Party_Private()
        {

        }
    }
}
