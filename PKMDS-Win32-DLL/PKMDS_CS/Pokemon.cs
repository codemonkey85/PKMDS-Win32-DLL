namespace PKMDS_CS;

[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
[Serializable]
public class Pokemon
{
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 136)]
    [Browsable(false)]
    public byte[] Data;
    internal void Decrypt() => DecryptPokemon(this);
    public void GetPTR(IntPtr ptr) => Marshal.StructureToPtr(this, ptr, false);
    public Pokemon(IntPtr ptr) => Data = ((Pokemon)Marshal.PtrToStructure(ptr, typeof(Pokemon))).Data;
    public Pokemon() => Data = new byte[136];
    [Browsable(true)]
    public Image TypePic1 => GetTypePic(1);
    [Browsable(true)]
    public Image TypePic2 => GetType(1) == GetType(2) ? null : GetTypePic(2);
    [Browsable(true)]
    public string SpeciesName => GetPKMName_FromObj(this);
    [Browsable(true)]
    public Image? Sprite => SpeciesID == 0
                ? null
                : SpeciesID != (ushort)PKMSpecies.Spinda
                ? GetSprite(SpeciesID, IsShiny, FormID, HasFemaleSprite(this) == 1)
                : GetSpindaSprite(PID, IsShiny);
    [Browsable(true)]
    public int[] GetStats
    {
        get
        {
            var ret = new int[6];
            for (var stat = 0; stat < ret.Length; stat++)
            {
                ret[stat] = GetPKMStat_FromObj(this, stat + 1);
            }
            return ret;
        }
    }
    [Browsable(true)]
    public int Level
    {
        get => GetPKMLevel(this);
        set => SetPKMLevel(this, value);
    }
    [Browsable(true)]
    public ushort SpeciesID
    {
        get => GetPKMSpeciesID(this);
        set
        {
            if ((value >= 0) & (value <= 649))
            {
                SetPKMSpeciesID(this, value);
            }
        }
    }
    public void WriteToFile(string FileName, bool encrypt = false) => WritePokemonFile(this, FileName, encrypt);
    [Browsable(true)]
    public uint PID
    {
        get => GetPKMPID(this);
        set => SetPKMPID(this, value);
    }
    [Browsable(true)]
    public ushort ItemID
    {
        get => GetPKMItemIndex(this);
        set => SetPKMItemIndex(this, value);
    }
    [Browsable(true)]
    public string ItemName => GetItemName(ItemID);
    [Browsable(true)]
    public string ItemFlavor
    {
        get
        {
            var flavor = GetItemFlavor(ItemID);
            return string.IsNullOrEmpty(flavor) ? flavor : flavor.Replace("\n", " ");
        }
    }
    [Browsable(true)]
    public ushort TID
    {
        get => GetPKMTID(this);
        set => SetPKMTID(this, value);
    }
    [Browsable(true)]
    public ushort SID
    {
        get => GetPKMSID(this);
        set => SetPKMSID(this, value);
    }
    [Browsable(true)]
    public uint EXP
    {
        get => GetPKMEXP(this);
        set => SetPKMEXP(this, value);
    }
    [Browsable(true)]
    public int Tameness
    {
        get => GetPKMTameness(this);
        set => SetPKMTameness(this, value);
    }
    [Browsable(true)]
    public ushort AbilityID
    {
        get => GetPKMAbilityIndex(this);
        set => SetPKMAbilityIndex(this, value);
    }
    public string AbilityFlavor => GetAbilityFlavor(AbilityID);
    private bool GetMarking(Markings marking) => GetPKMMarking(this, (int)marking);
    private void SetMarking(Markings marking, bool marked) => SetPKMMarking(this, (int)marking, marked);
    [Browsable(true)]
    public byte LanguageID
    {
        get => GetPKMLanguage(this);
        set => SetPKMLanguage(this, value);
    }
    public int GetEV(int evindex) => GetPKMEV(this, evindex);
    public void SetEV(int evindex, int ev) => SetPKMEV(this, evindex, ev);
    public int GetIV(int ivindex) => GetPKMIV(this, ivindex);
    public void SetIV(int ivindex, int iv) => SetPKMIV(this, ivindex, iv);
    public int GetContest(int contestindex) => GetPKMContest(this, contestindex);
    public void SetContest(int contestindex, int contest) => SetPKMContest(this, contestindex, contest);
    [Browsable(true)]
    public ushort[] GetMoveIDs
    {
        get
        {
            ushort[] moveids = { 0, 0, 0, 0 };
            for (var movenum = 0; movenum < 4; movenum++)
            {
                moveids[movenum] = GetPKMMoveID(this, movenum);
            }
            return moveids;
        }
    }
    public void SetMoveID(int moveid, ushort movenum) => SetPKMMoveID(this, moveid, movenum);
    public int GetMovePP(int move) => GetPKMMovePP(this, move);
    public void SetMovePP(int move, int pp) => SetPKMMovePP(this, move, pp);
    public int GetMovePPUp(int move) => GetPKMMovePPUp(this, move);
    public void SetMovePPUp(int move, int ppup) => SetPKMMovePPUp(this, move, ppup);
    [Browsable(true)]
    public bool MetAsEgg
    {
        get => GetPKMMetAsEgg(this);
        set
        {
            if (value)
            {
                EggDate = DateTime.Today;
                EggLocationID = 1;
            }
            else
            {
                SetNoEggDate();
                EggLocationID = 0;
            }
        }
    }
    [Browsable(true)]
    public bool IsEgg
    {
        get => GetPKMIsEgg(this) == 1;
        set => SetPKMIsEgg(this, value);
    }
    [Browsable(true)]
    public bool IsNicknamed
    {
        get => GetPKMIsNicknamed(this) == 1;
        set => SetPKMIsNicknamed(this, value);
    }
    [Browsable(true)]
    public bool IsFateful
    {
        get => GetPKMFateful(this) == 1;
        set => SetPKMFateful(this, value);
    }
    [Browsable(true)]
    public int GenderID
    {
        get => GetPKMGender(this);
        set => SetPKMGender(this, value);
    }
    [Browsable(true)]
    public byte FormID
    {
        get => GetPKMForm(this);
        set => SetPKMForm(this, value);
    }
    [Browsable(true)]
    public byte NatureID
    {
        get => GetPKMNature(this);
        set => SetPKMNature(this, value);
    }
    [Browsable(true)]
    public bool HasDWAbility
    {
        get => GetPKMDWAbility(this);
        set => SetPKMDWAbility(this, value);
    }
    [Browsable(true)]
    public bool IsNsPokemon
    {
        get => GetPKMNsPokemon(this) == 1;
        set => SetPKMNsPokemon(this, value);
    }
    [Browsable(true)]
    public string Nickname
    {
        get => GetPKMNickname(this);
        set
        {
            value ??= string.Empty;
            SetPKMNickname(this, value, value.Length);
        }
    }
    [Browsable(true)]
    public byte HometownID
    {
        get => GetPKMHometown(this);
        set => SetPKMHometown(this, value);
    }
    [Browsable(true)]
    public string OTName
    {
        get => GetPKMOTName(this);
        set
        {
            value ??= string.Empty;
            SetPKMOTName(this, value, value.Length);
        }
    }
    public void SetNoEggDate()
    {
        Data[0x78] = 0;
        Data[0x79] = 0;
        Data[0x7A] = 0;
    }
    [Browsable(true)]
    public DateTime EggDate
    {
        get
        {
            try
            {
                return new DateTime(GetPKMEggYear(this), GetPKMEggMonth(this), GetPKMEggDay(this));
            }
            catch
            {
                return new DateTime();
            }
        }
        set
        {
            SetPKMEggYear(this, value.Year);
            SetPKMEggMonth(this, value.Month);
            SetPKMEggDay(this, value.Day);
        }
    }
    [Browsable(true)]
    public DateTime MetDate
    {
        get
        {
            try
            {
                return new DateTime(GetPKMMetYear(this), GetPKMMetMonth(this), GetPKMMetDay(this));
            }
            catch
            {
                return new DateTime();
            }
        }
        set
        {
            SetPKMMetYear(this, value.Year);
            SetPKMMetMonth(this, value.Month);
            SetPKMMetDay(this, value.Day);
        }
    }
    [Browsable(true)]
    public ushort EggLocationID
    {
        get => GetPKMEggLocation(this);
        set => SetPKMEggLocation(this, value);
    }
    [Browsable(true)]
    public ushort MetLocationID
    {
        get => GetPKMMetLocation(this);
        set => SetPKMMetLocation(this, value);
    }
    [Browsable(true)]
    public int PokerusStrain
    {
        get => GetPKMPokerusStrain(this);
        set => SetPKMPokerusStrain(this, value);
    }
    [Browsable(true)]
    public int PokerusDays
    {
        get => GetPKMPokerusDays(this);
        set => SetPKMPokerusDays(this, value);
    }
    [Browsable(true)]
    public byte BallID
    {
        get => GetPKMBall(this);
        set => SetPKMBall(this, value);
    }
    [Browsable(true)]
    public int MetLevel
    {
        get => Convert.ToInt32(GetPKMMetLevel(this));
        set => SetPKMMetLevel(this, Convert.ToByte(value));
    }
    [Browsable(true)]
    public int OTGenderID
    {
        get => GetPKMOTGender(this);
        set => SetPKMOTGender(this, value);
    }
    [Browsable(true)]
    public int EncounterID
    {
        get => GetPKMEncounter(this);
        set => SetPKMEncounter(this, value);
    }
    [Browsable(true)]
    public bool IsModified => IsPKMModified(this);
    public void FixChecksum() => FixPokemonChecksum(this);
    [Browsable(true)]
    public Image Icon => SpeciesID == 0 ? null : GetIcon(SpeciesID, FormID, HasFemaleIcon(this) == 1);
    [Browsable(true)]
    public bool IsShiny => IsPKMShiny(this);
    public int GetType(int Slot) => GetPKMType(this, Slot);
    public Image GetTypePic(int Slot) => Slot is 1 or 2 ? GetTypeImage(GetType(Slot)) : null;
    [Browsable(true)]
    public uint TNL => GetPKMTNL(this);
    public double TNLPercent
    {
        get
        {
            if (TNL == 0)
            {
                return 0.0;
            }
            double min = EXP - EXPAtCurLevel;
            double max = EXPAtNextLevel - EXPAtCurLevel;
            var percent = (double)(min / max);
            return percent;
        }
    }
    public uint EXPAtNextLevel => TNL == 0 ? EXP : EXPAtGivenLevel(Level + 1);
    [Browsable(true)]
    public uint EXPAtCurLevel => GetPKMEXPCurLevel(this);
    public uint EXPAtGivenLevel(int Level) => GetPKMEXPGivenLevel(this, Level);
    [Browsable(true)]
    public Color Color => ColorTranslator.FromHtml($"#{GetPKMColorValue(this):X6}");
    [Browsable(true)]
    public Image ShinyIcon => GetShinyStar(IsShiny);
    [Browsable(true)]
    public Image GenderIcon => GetGenderIcon(GenderID);
    [Browsable(true)]
    public Image ItemPic => ItemID == 0 ? null : GetItemImage(ItemID);
    private Image GetMarkingImage(Markings marking) => PKMDS.GetMarkingImage(marking, GetMarking(marking));
    [Browsable(true)]
    public Image BallPic => GetBallImage(BallID);
    public static Image MoveCategoryPic(ushort move) => GetMoveCategoryImage(move);
    [Browsable(true)]
    public Image PokerusIcon => PokerusStrain > 0 ? PokerusDays > 0 ? GetResourceByName("pokerus_infected") : GetResourceByName("pokerus_cured") : null;
    [Browsable(true)]
    public string Characteristic => GetCharacteristic(this);
    [Browsable(true)]
    public int NatureIncrease => GetNatureIncrease(this);
    [Browsable(true)]
    public int NatureDecrease => GetNatureDecrease(this);
    public string NatureName => GetNatureName(NatureID);
    [Browsable(true)]
    public int TotalEVs
    {
        get
        {
            var total = 0;
            for (var i = 0; i < 6; i++)
            {
                total += GetEV(i);
            }
            return total;
        }
    }
    [Browsable(true)]
    public bool Diamond { get => GetMarking(Markings.Diamond); set => SetMarking(Markings.Diamond, value); }
    [Browsable(true)]
    public bool Heart { get => GetMarking(Markings.Heart); set => SetMarking(Markings.Heart, value); }
    [Browsable(true)]
    public bool Circle { get => GetMarking(Markings.Circle); set => SetMarking(Markings.Circle, value); }
    [Browsable(true)]
    public bool Triangle { get => GetMarking(Markings.Triangle); set => SetMarking(Markings.Triangle, value); }
    [Browsable(true)]
    public bool Star { get => GetMarking(Markings.Star); set => SetMarking(Markings.Star, value); }
    [Browsable(true)]
    public bool Square { get => GetMarking(Markings.Square); set => SetMarking(Markings.Square, value); }
    public bool OTIsMale
    {
        get => OTGenderID == 0;
        set => OTGenderID = value ? 0 : 1;
    }
    public bool OTIsFemale
    {
        get => OTGenderID == 1;
        set => OTGenderID = value ? 1 : 0;
    }
    public NatureEffect AttackEffect => NatureIncrease == NatureDecrease
                ? NatureEffect.NoEffect
                : NatureIncrease == (int)NatureStats.Attack
                ? NatureEffect.Increase
                : NatureDecrease == (int)NatureStats.Attack ? NatureEffect.Decrease : NatureEffect.NoEffect;
    public NatureEffect DefenseEffect => NatureIncrease == NatureDecrease
                ? NatureEffect.NoEffect
                : NatureIncrease == (int)NatureStats.Defense
                ? NatureEffect.Increase
                : NatureDecrease == (int)NatureStats.Defense ? NatureEffect.Decrease : NatureEffect.NoEffect;
    public NatureEffect SpecialAttackEffect => NatureIncrease == NatureDecrease
                ? NatureEffect.NoEffect
                : NatureIncrease == (int)NatureStats.SpecialAttack
                ? NatureEffect.Increase
                : NatureDecrease == (int)NatureStats.SpecialAttack ? NatureEffect.Decrease : NatureEffect.NoEffect;
    public NatureEffect SpecialDefenseEffect => NatureIncrease == NatureDecrease
                ? NatureEffect.NoEffect
                : NatureIncrease == (int)NatureStats.SpecialDefense
                ? NatureEffect.Increase
                : NatureDecrease == (int)NatureStats.SpecialDefense ? NatureEffect.Decrease : NatureEffect.NoEffect;
    public NatureEffect SpeedEffect => NatureIncrease == NatureDecrease
                ? NatureEffect.NoEffect
                : NatureIncrease == (int)NatureStats.Speed
                ? NatureEffect.Increase
                : NatureDecrease == (int)NatureStats.Speed ? NatureEffect.Decrease : NatureEffect.NoEffect;
    public ushort Move1ID
    {
        get => GetMoveIDs[0];
        set => SetMoveID(0, value);
    }
    public ushort Move2ID
    {
        get => GetMoveIDs[1];
        set => SetMoveID(1, value);
    }
    public ushort Move3ID
    {
        get => GetMoveIDs[2];
        set => SetMoveID(2, value);
    }
    public ushort Move4ID
    {
        get => GetMoveIDs[3];
        set => SetMoveID(3, value);
    }
    public int Move1PP
    {
        get => GetMovePP(0);
        set => SetMovePP(0, value);
    }
    public int Move1PPUps
    {
        get => GetMovePPUp(0);
        set => SetMovePPUp(0, value);
    }
    public int Move2PP
    {
        get => GetMovePP(1);
        set => SetMovePP(1, value);
    }
    public int Move2PPUps
    {
        get => GetMovePPUp(1);
        set => SetMovePPUp(1, value);
    }
    public int Move3PP
    {
        get => GetMovePP(2);
        set => SetMovePP(2, value);
    }
    public int Move3PPUps
    {
        get => GetMovePPUp(2);
        set => SetMovePPUp(2, value);
    }
    public int Move4PP
    {
        get => GetMovePP(3);
        set => SetMovePP(3, value);
    }
    public int Move4PPUps
    {
        get => GetMovePPUp(3);
        set => SetMovePPUp(3, value);
    }
    public double Move1MaxPP
    {
        get
        {
            double basepp = GetMoveBasePP(Move1ID);
            return basepp + GetMovePPUp(0) * (basepp / 5);
        }
    }
    public double Move2MaxPP
    {
        get
        {
            double basepp = GetMoveBasePP(Move2ID);
            return basepp + GetMovePPUp(1) * (basepp / 5);
        }
    }
    public double Move3MaxPP
    {
        get
        {
            double basepp = GetMoveBasePP(Move3ID);
            return basepp + GetMovePPUp(2) * (basepp / 5);
        }
    }
    public double Move4MaxPP
    {
        get
        {
            double basepp = GetMoveBasePP(Move4ID);
            return basepp + GetMovePPUp(3) * (basepp / 5);
        }
    }
    public int HPIV
    {
        get => GetIV(0);
        set => SetIV(0, value);
    }
    public int AttackIV
    {
        get => GetIV(1);
        set => SetIV(1, value);
    }
    public int DefenseIV
    {
        get => GetIV(2);
        set => SetIV(2, value);
    }
    public int SpecialAttackIV
    {
        get => GetIV(3);
        set => SetIV(3, value);
    }
    public int SpecialDefenseIV
    {
        get => GetIV(4);
        set => SetIV(4, value);
    }
    public int SpeedIV
    {
        get => GetIV(5);
        set => SetIV(5, value);
    }
    public int HPEV
    {
        get => GetEV(0);
        set => SetEV(0, value);
    }
    public int AttackEV
    {
        get => GetEV(1);
        set => SetEV(1, value);
    }
    public int DefenseEV
    {
        get => GetEV(2);
        set => SetEV(2, value);
    }
    public int SpecialAttackEV
    {
        get => GetEV(3);
        set => SetEV(3, value);
    }
    public int SpecialDefenseEV
    {
        get => GetEV(4);
        set => SetEV(4, value);
    }
    public int SpeedEV
    {
        get => GetEV(5);
        set => SetEV(5, value);
    }
    public int CalculatedHP => GetPKMStat_FromObj(this, 1);
    public int CalculatedAttack => GetPKMStat_FromObj(this, 2);
    public int CalculatedDefense => GetPKMStat_FromObj(this, 3);
    public int CalculatedSpecialAttack => GetPKMStat_FromObj(this, 4);
    public int CalculatedSpecialDefense => GetPKMStat_FromObj(this, 5);
    public int CalculatedSpeed => GetPKMStat_FromObj(this, 6);
    public int MaxEXP => (int)GetPKMEXPGivenLevel(this, 100);
    public int Move1Power => GetMovePower(Move1ID);
    public int Move1Accuracy => GetMoveAccuracy(Move1ID);
    public int Move2Power => GetMovePower(Move2ID);
    public int Move2Accuracy => GetMoveAccuracy(Move2ID);
    public int Move3Power => GetMovePower(Move3ID);
    public int Move3Accuracy => GetMoveAccuracy(Move3ID);
    public int Move4Power => GetMovePower(Move4ID);
    public int Move4Accuracy => GetMoveAccuracy(Move4ID);
    public Image Move1TypePic => Move1ID == 0 ? null : GetResourceByName(GetMoveTypeName(Move1ID).ToLower());
    public Image Move1CategoryPic => GetMoveCategoryImage(Move1ID);
    public Image Move2TypePic => Move2ID == 0 ? null : GetResourceByName(GetMoveTypeName(Move2ID).ToLower());
    public Image Move2CategoryPic => GetMoveCategoryImage(Move2ID);
    public Image Move3TypePic => Move3ID == 0 ? null : GetResourceByName(GetMoveTypeName(Move3ID).ToLower());
    public Image Move3CategoryPic => GetMoveCategoryImage(Move3ID);
    public Image Move4TypePic => Move4ID == 0 ? null : GetResourceByName(GetMoveTypeName(Move4ID).ToLower());
    public Image Move4CategoryPic => GetMoveCategoryImage(Move4ID);
    public string Move1Flavor => GetMoveFlavor(Move1ID);
    public string Move2Flavor => GetMoveFlavor(Move2ID);
    public string Move3Flavor => GetMoveFlavor(Move3ID);
    public string Move4Flavor => GetMoveFlavor(Move4ID);
    public Pokemon Clone()
    {
        var ClonedData = new byte[Data.Length];
        Data.CopyTo(ClonedData, 0);
        return new Pokemon { Data = ClonedData };
    }
}
