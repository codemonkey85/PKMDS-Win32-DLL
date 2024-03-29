﻿namespace PKMDS_CS;

public class Save
{
    internal SaveData InternalSave;
    public Party Party;
    public PCStorage PCStorage;
    public BoxNames BoxNames;
    public BoxWallpapers BoxWallpapers;
    public Save(string filename)
    {
        InternalSave = ReadSaveFile(filename);
        InitializePCStorage();
        InitializeParty();
    }

    private void InitializePCStorage()
    {
        PCStorage = new PCStorage();
        BoxNames = new BoxNames();
        BoxWallpapers = new BoxWallpapers();
        PCStorage.Reset();
        for (var box = 0; box < 24; box++)
        {
            BoxNames.Add(InternalSave.BoxNames.Boxes(box));
            BoxWallpapers.Add(InternalSave.BoxWallpapers.Wallpapers(box));
            for (var slot = 0; slot < 30; slot++)
            {
                var pkmn = InternalSave.PCStorage.Box(box).Pokemon(slot);
                PCStorage[box].Add(pkmn);
                pkmn.Decrypt();
            }
        }
    }
    private void InitializeParty()
    {
        Party = new Party();
        for (var slot = 0; slot < 6; slot++)
        {
            Party.Add(InternalSave.Party.Pokemon(slot));
            Party[slot].Decrypt();
        }
    }
    public void RecalculateParty()
    {
        foreach (var ppkm in Party)
        {
            if (ppkm.PokemonData.SpeciesID != 0)
            {
                RecalcPartyPKM(ppkm);
            }
        }
    }
    public void WriteToFile(string filename) => InternalSave.WriteToFile(filename);
    public string TrainerName
    {
        get => InternalSave.TrainerName;
        set => InternalSave.TrainerName = value;
    }
    public ushort TID
    {
        get => InternalSave.TID;
        set => InternalSave.TID = value;
    }
    public ushort SID
    {
        get => InternalSave.SID;
        set => InternalSave.SID = value;
    }
    private Image BoxWallpaper1 => InternalSave.GetBoxWallpaper(0);
    private Image BoxWallpaper2 => InternalSave.GetBoxWallpaper(1);
    private Image BoxWallpaper3 => InternalSave.GetBoxWallpaper(2);
    private Image BoxWallpaper4 => InternalSave.GetBoxWallpaper(3);
    private Image BoxWallpaper5 => InternalSave.GetBoxWallpaper(4);
    private Image BoxWallpaper6 => InternalSave.GetBoxWallpaper(5);
    private Image BoxWallpaper7 => InternalSave.GetBoxWallpaper(6);
    private Image BoxWallpaper8 => InternalSave.GetBoxWallpaper(7);
    private Image BoxWallpaper9 => InternalSave.GetBoxWallpaper(8);
    private Image BoxWallpaper10 => InternalSave.GetBoxWallpaper(9);
    private Image BoxWallpaper11 => InternalSave.GetBoxWallpaper(10);
    private Image BoxWallpaper12 => InternalSave.GetBoxWallpaper(11);
    private Image BoxWallpaper13 => InternalSave.GetBoxWallpaper(12);
    private Image BoxWallpaper14 => InternalSave.GetBoxWallpaper(13);
    private Image BoxWallpaper15 => InternalSave.GetBoxWallpaper(14);
    private Image BoxWallpaper16 => InternalSave.GetBoxWallpaper(15);
    private Image BoxWallpaper17 => InternalSave.GetBoxWallpaper(16);
    private Image BoxWallpaper18 => InternalSave.GetBoxWallpaper(17);
    private Image BoxWallpaper19 => InternalSave.GetBoxWallpaper(18);
    private Image BoxWallpaper20 => InternalSave.GetBoxWallpaper(19);
    private Image BoxWallpaper21 => InternalSave.GetBoxWallpaper(20);
    private Image BoxWallpaper22 => InternalSave.GetBoxWallpaper(21);
    private Image BoxWallpaper23 => InternalSave.GetBoxWallpaper(22);
    private Image BoxWallpaper24 => InternalSave.GetBoxWallpaper(23);
    public byte CurrentBox
    {
        get => InternalSave.CurrentBox;
        set => InternalSave.CurrentBox = value;
    }
    public int PartySize
    {
        get => InternalSave.PartySize;
        set => InternalSave.PartySize = value;
    }
    public int BoxCount(int box) => InternalSave.BoxCount(box);
    public bool DepositPokemon(Pokemon pokemon, int box)
    {
        if (BoxCount(box) == 30)
        {
            return false;
        }
        var boxint = 0;
        var slotint = 0;
        unsafe
        {
            var boxptr = &boxint;
            var slotptr = &slotint;
            GetPCStorageAvailableSlot(this, boxptr, slotptr, box);
        }
        PCStorage[boxint][slotint].Data = pokemon.Data;
        FixParty(this);
        return true;
    }
    public bool WithdrawPokemon(Pokemon pokemon)
    {
        if (PartySize == 6)
        {
            return false;
        }
        for (var slot = 0; slot < 6; slot++)
        {
            var ppkm = Party[slot];
            if (ppkm.PokemonData.SpeciesID == 0)
            {
                ppkm.PokemonData.Data = pokemon.Data;
                RecalcPartyPKM(ppkm);
                FixParty(this);
                return true;
            }
        }
        return false;
    }
    public void RemovePartyPokemon(int slot)
    {
        if (PartySize <= 1)
        {
            return;
        }
        var ppkm = new PartyPokemon();
        ppkm.PokemonData.SpeciesID = 0;
        Party[slot] = ppkm;
        FixParty(this);
    }
    public void RemoveStoredPokemon(int box, int slot) => PCStorage[box][slot] = new Pokemon
    {
        SpeciesID = 0
    };
}
