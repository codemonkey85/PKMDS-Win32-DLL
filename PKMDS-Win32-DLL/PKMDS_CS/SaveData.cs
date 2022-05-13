using System;
using System.Drawing;
using System.Runtime.InteropServices;
using static PKMDS_CS.PKMDS;

namespace PKMDS_CS
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    [Serializable]
    internal class SaveData
    {
        public byte CurrentBox;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 0x3)]
        private readonly byte[] FirstBuff;
        public BoxNames_Private BoxNames;
        public BoxWallpapers_Private BoxWallpapers;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 0x24)]
        private readonly byte[] SecondBuff;
        public PCStorage_Private PCStorage;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 0xA00)]
        private readonly byte[] Inventory;
        public Party_Private Party;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 0x66CC4)]
        private readonly byte[] ThirdBuff;
        public string TrainerName
        {
            get => GetTrainerName_FromSav(this);
            set => SetTrainerName_FromSav(this, value);
        }
        public ushort TID
        {
            get => GetTrainerTID_FromSav(this);
            set => SetTrainerTID_FromSav(this, value);
        }
        public ushort SID
        {
            get => GetTrainerSID_FromSav(this);
            set => SetTrainerSID_FromSav(this, value);
        }
        public string GetBoxName(int Box) => PKMDS.GetBoxName(this, Box);
        public void SetBoxName(int Box, string Name) => PKMDS.SetBoxName(this, Box, Name, Name.Length);
        public int GetBoxWallpaperIndex(int Box) => PKMDS.GetBoxWallpaper(this, Box);
        public void SetBoxWallpaperIndex(int Box, int Wallpaper) => SetBoxWallpaper(this, Box, Wallpaper);
        public Image GetBoxWallpaper(int box) => GetWallpaperImage(GetBoxWallpaperIndex(box));
        public void WriteToFile(string FileName) => WriteSaveFile(this, FileName);
        private Pokemon GetStoredPokemon(int Box, int Slot)
        {
            Pokemon pkm = new Pokemon();
            GetPKMData(ref pkm, this, Box, Slot);
            return pkm;
        }
        private void SetStoredPokemon(Pokemon pokemon, int Box, int Slot) => SetPKMData(pokemon, this, Box, Slot);
        private PartyPokemon GetPartyPokemon(int Slot)
        {
            PartyPokemon pkm = new PartyPokemon();
            GetPartyPKMData(ref pkm, this, Slot);
            return pkm;
        }
        private void SetPartyPokemon(PartyPokemon pokemon, int Slot) => SetPartyPKMData(pokemon, this, Slot);
        public int PartySize
        {
            get => GetPartySize(this);
            set => SetPartySize(this, value);
        }
        public int BoxCount(int box) => GetBoxCount(this, box);
        public bool DepositPokemon(Pokemon pokemon, int box) => DepositPKM(this, pokemon, box, true);
        public bool WithdrawPokemon(Pokemon pokemon) => WithdrawPKM(this, pokemon);
        public void RemovePartyPokemon(int slot) => DeletePartyPKM(this, slot);
        public void RecalculateParty()
        {
            for (int slot = 0; slot < PartySize; slot++)
            {
                PartyPokemon ppkm = GetPartyPokemon(slot);
                if (ppkm.PokemonData.SpeciesID != 0)
                {
                    RecalcPartyPKM(ppkm);
                    SetPartyPokemon(ppkm, slot);
                }
            }
        }
        public void RemoveStoredPokemon(int box, int slot) => DeleteStoredPKM(this, box, slot);
        public bool Validate(out string message) => ValidateSave(this, out message);
    }
}
