using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
// TODO: add all enums and classes to talk to DLL
namespace PKMDS_CS
{
    enum stats
    {
        HP = 1,
        Attack,
        Defense,
        SpAtk,
        SpDef,
        Speed
    };

    namespace Species
    {
        public enum species : ushort
        {
            NOTHING,
            bulbasaur,
            ivysaur,
            venusaur,
            charmander,
            charmeleon,
            charizard,
            squirtle,
            wartortle,
            blastoise,
            caterpie,
            metapod,
            butterfree,
            weedle,
            kakuna,
            beedrill,
            pidgey,
            pidgeotto,
            pidgeot,
            rattata,
            raticate,
            spearow,
            fearow,
            ekans,
            arbok,
            pikachu,
            raichu,
            sandshrew,
            sandslash,
            nidoran_f,
            nidorina,
            nidoqueen,
            nidoran_m,
            nidorino,
            nidoking,
            clefairy,
            clefable,
            vulpix,
            ninetales,
            jigglypuff,
            wigglytuff,
            zubat,
            golbat,
            oddish,
            gloom,
            vileplume,
            paras,
            parasect,
            venonat,
            venomoth,
            diglett,
            dugtrio,
            meowth,
            persian,
            psyduck,
            golduck,
            mankey,
            primeape,
            growlithe,
            arcanine,
            poliwag,
            poliwhirl,
            poliwrath,
            abra,
            kadabra,
            alakazam,
            machop,
            machoke,
            machamp,
            bellsprout,
            weepinbell,
            victreebel,
            tentacool,
            tentacruel,
            geodude,
            graveler,
            golem,
            ponyta,
            rapidash,
            slowpoke,
            slowbro,
            magnemite,
            magneton,
            farfetch_d,
            doduo,
            dodrio,
            seel,
            dewgong,
            grimer,
            muk,
            shellder,
            cloyster,
            gastly,
            haunter,
            gengar,
            onix,
            drowzee,
            hypno,
            krabby,
            kingler,
            voltorb,
            electrode,
            exeggcute,
            exeggutor,
            cubone,
            marowak,
            hitmonlee,
            hitmonchan,
            lickitung,
            koffing,
            weezing,
            rhyhorn,
            rhydon,
            chansey,
            tangela,
            kangaskhan,
            horsea,
            seadra,
            goldeen,
            seaking,
            staryu,
            starmie,
            mr_mime,
            scyther,
            jynx,
            electabuzz,
            magmar,
            pinsir,
            tauros,
            magikarp,
            gyarados,
            lapras,
            ditto,
            eevee,
            vaporeon,
            jolteon,
            flareon,
            porygon,
            omanyte,
            omastar,
            kabuto,
            kabutops,
            aerodactyl,
            snorlax,
            articuno,
            zapdos,
            moltres,
            dratini,
            dragonair,
            dragonite,
            mewtwo,
            mew,
            chikorita,
            bayleef,
            meganium,
            cyndaquil,
            quilava,
            typhlosion,
            totodile,
            croconaw,
            feraligatr,
            sentret,
            furret,
            hoothoot,
            noctowl,
            ledyba,
            ledian,
            spinarak,
            ariados,
            crobat,
            chinchou,
            lanturn,
            pichu,
            cleffa,
            igglybuff,
            togepi,
            togetic,
            natu,
            xatu,
            mareep,
            flaaffy,
            ampharos,
            bellossom,
            marill,
            azumarill,
            sudowoodo,
            politoed,
            hoppip,
            skiploom,
            jumpluff,
            aipom,
            sunkern,
            sunflora,
            yanma,
            wooper,
            quagsire,
            espeon,
            umbreon,
            murkrow,
            slowking,
            misdreavus,
            unown,
            wobbuffet,
            girafarig,
            pineco,
            forretress,
            dunsparce,
            gligar,
            steelix,
            snubbull,
            granbull,
            qwilfish,
            scizor,
            shuckle,
            heracross,
            sneasel,
            teddiursa,
            ursaring,
            slugma,
            magcargo,
            swinub,
            piloswine,
            corsola,
            remoraid,
            octillery,
            delibird,
            mantine,
            skarmory,
            houndour,
            houndoom,
            kingdra,
            phanpy,
            donphan,
            porygon2,
            stantler,
            smeargle,
            tyrogue,
            hitmontop,
            smoochum,
            elekid,
            magby,
            miltank,
            blissey,
            raikou,
            entei,
            suicune,
            larvitar,
            pupitar,
            tyranitar,
            lugia,
            ho_oh,
            celebi,
            treecko,
            grovyle,
            sceptile,
            torchic,
            combusken,
            blaziken,
            mudkip,
            marshtomp,
            swampert,
            poochyena,
            mightyena,
            zigzagoon,
            linoone,
            wurmple,
            silcoon,
            beautifly,
            cascoon,
            dustox,
            lotad,
            lombre,
            ludicolo,
            seedot,
            nuzleaf,
            shiftry,
            taillow,
            swellow,
            wingull,
            pelipper,
            ralts,
            kirlia,
            gardevoir,
            surskit,
            masquerain,
            shroomish,
            breloom,
            slakoth,
            vigoroth,
            slaking,
            nincada,
            ninjask,
            shedinja,
            whismur,
            loudred,
            exploud,
            makuhita,
            hariyama,
            azurill,
            nosepass,
            skitty,
            delcatty,
            sableye,
            mawile,
            aron,
            lairon,
            aggron,
            meditite,
            medicham,
            electrike,
            manectric,
            plusle,
            minun,
            volbeat,
            illumise,
            roselia,
            gulpin,
            swalot,
            carvanha,
            sharpedo,
            wailmer,
            wailord,
            numel,
            camerupt,
            torkoal,
            spoink,
            grumpig,
            spinda,
            trapinch,
            vibrava,
            flygon,
            cacnea,
            cacturne,
            swablu,
            altaria,
            zangoose,
            seviper,
            lunatone,
            solrock,
            barboach,
            whiscash,
            corphish,
            crawdaunt,
            baltoy,
            claydol,
            lileep,
            cradily,
            anorith,
            armaldo,
            feebas,
            milotic,
            castform,
            kecleon,
            shuppet,
            banette,
            duskull,
            dusclops,
            tropius,
            chimecho,
            absol,
            wynaut,
            snorunt,
            glalie,
            spheal,
            sealeo,
            walrein,
            clamperl,
            huntail,
            gorebyss,
            relicanth,
            luvdisc,
            bagon,
            shelgon,
            salamence,
            beldum,
            metang,
            metagross,
            regirock,
            regice,
            registeel,
            latias,
            latios,
            kyogre,
            groudon,
            rayquaza,
            jirachi,
            deoxys,
            turtwig,
            grotle,
            torterra,
            chimchar,
            monferno,
            infernape,
            piplup,
            prinplup,
            empoleon,
            starly,
            staravia,
            staraptor,
            bidoof,
            bibarel,
            kricketot,
            kricketune,
            shinx,
            luxio,
            luxray,
            budew,
            roserade,
            cranidos,
            rampardos,
            shieldon,
            bastiodon,
            burmy,
            wormadam,
            mothim,
            combee,
            vespiquen,
            pachirisu,
            buizel,
            floatzel,
            cherubi,
            cherrim,
            shellos,
            gastrodon,
            ambipom,
            drifloon,
            drifblim,
            buneary,
            lopunny,
            mismagius,
            honchkrow,
            glameow,
            purugly,
            chingling,
            stunky,
            skuntank,
            bronzor,
            bronzong,
            bonsly,
            mime_jr,
            happiny,
            chatot,
            spiritomb,
            gible,
            gabite,
            garchomp,
            munchlax,
            riolu,
            lucario,
            hippopotas,
            hippowdon,
            skorupi,
            drapion,
            croagunk,
            toxicroak,
            carnivine,
            finneon,
            lumineon,
            mantyke,
            snover,
            abomasnow,
            weavile,
            magnezone,
            lickilicky,
            rhyperior,
            tangrowth,
            electivire,
            magmortar,
            togekiss,
            yanmega,
            leafeon,
            glaceon,
            gliscor,
            mamoswine,
            porygon_z,
            gallade,
            probopass,
            dusknoir,
            froslass,
            rotom,
            uxie,
            mesprit,
            azelf,
            dialga,
            palkia,
            heatran,
            regigigas,
            giratina,
            cresselia,
            phione,
            manaphy,
            darkrai,
            shaymin,
            arceus,
            victini,
            snivy,
            servine,
            serperior,
            tepig,
            pignite,
            emboar,
            oshawott,
            dewott,
            samurott,
            patrat,
            watchog,
            lillipup,
            herdier,
            stoutland,
            purrloin,
            liepard,
            pansage,
            simisage,
            pansear,
            simisear,
            panpour,
            simipour,
            munna,
            musharna,
            pidove,
            tranquill,
            unfezant,
            blitzle,
            zebstrika,
            roggenrola,
            boldore,
            gigalith,
            woobat,
            swoobat,
            drilbur,
            excadrill,
            audino,
            timburr,
            gurdurr,
            conkeldurr,
            tympole,
            palpitoad,
            seismitoad,
            throh,
            sawk,
            sewaddle,
            swadloon,
            leavanny,
            venipede,
            whirlipede,
            scolipede,
            cottonee,
            whimsicott,
            petilil,
            lilligant,
            basculin,
            sandile,
            krokorok,
            krookodile,
            darumaka,
            darmanitan,
            maractus,
            dwebble,
            crustle,
            scraggy,
            scrafty,
            sigilyph,
            yamask,
            cofagrigus,
            tirtouga,
            carracosta,
            archen,
            archeops,
            trubbish,
            garbodor,
            zorua,
            zoroark,
            minccino,
            cinccino,
            gothita,
            gothorita,
            gothitelle,
            solosis,
            duosion,
            reuniclus,
            ducklett,
            swanna,
            vanillite,
            vanillish,
            vanilluxe,
            deerling,
            sawsbuck,
            emolga,
            karrablast,
            escavalier,
            foongus,
            amoonguss,
            frillish,
            jellicent,
            alomomola,
            joltik,
            galvantula,
            ferroseed,
            ferrothorn,
            klink,
            klang,
            klinklang,
            tynamo,
            eelektrik,
            eelektross,
            elgyem,
            beheeyem,
            litwick,
            lampent,
            chandelure,
            axew,
            fraxure,
            haxorus,
            cubchoo,
            beartic,
            cryogonal,
            shelmet,
            accelgor,
            stunfisk,
            mienfoo,
            mienshao,
            druddigon,
            golett,
            golurk,
            pawniard,
            bisharp,
            bouffalant,
            rufflet,
            braviary,
            vullaby,
            mandibuzz,
            heatmor,
            durant,
            deino,
            zweilous,
            hydreigon,
            larvesta,
            volcarona,
            cobalion,
            terrakion,
            virizion,
            tornadus,
            thundurus,
            reshiram,
            zekrom,
            landorus,
            kyurem,
            keldeo,
            meloetta,
            genesect
        };
    }

    public class PKMDS
    {
        private const string PKMDS_WIN32_DLL = "PKMDS-Win32-DLL.dll";

        private const int LANG_ID = 9;
        private const int VERSION_GROUP = 11;
        private const int GENERATION = 5;
        private const int BUFF_SIZE = 955;
        private const int NICKLENGTH = 11;
        private const int OTLENGTH = 8;

        [DllImport(PKMDS_WIN32_DLL, CallingConvention = CallingConvention.Cdecl)]
        public static extern void OpenDB(string dbfilename);

        [DllImport(PKMDS_WIN32_DLL, CallingConvention = CallingConvention.Cdecl)]
        public static extern void CloseDB();

        [DllImport(PKMDS_WIN32_DLL, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.BStr)]
        public static extern string GetPKMName(int speciesid, int langid = LANG_ID);

        [DllImport(PKMDS_WIN32_DLL, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.BStr)]
        public static extern string GetPKMName_FromObj(Pokemon pkm/*, int box, int slot*/);

        [DllImport(PKMDS_WIN32_DLL, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.BStr)]
        public static extern string GetTrainerName_FromSav(Save sav);

        [DllImport(PKMDS_WIN32_DLL, CallingConvention = CallingConvention.Cdecl)]
        public static extern int GetTrainerTID_FromSav(Save sav);

        [DllImport(PKMDS_WIN32_DLL, CallingConvention = CallingConvention.Cdecl)]
        public static extern int GetTrainerSID_FromSav(Save sav);

        [DllImport(PKMDS_WIN32_DLL, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.BStr)]
        public static extern string GetBoxName(Save sav, int box);

        [DllImport(PKMDS_WIN32_DLL, CallingConvention = CallingConvention.Cdecl)]
        public static extern int GetPKMStat(Save sav, int box, int slot, int stat);

        [DllImport(PKMDS_WIN32_DLL, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.BStr)]
        public static extern string GetItemName(int itemid, int generation, int langid = LANG_ID);

        [DllImport(PKMDS_WIN32_DLL, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.BStr)]
        public static extern string GetMoveName(int moveid, int langid = LANG_ID);

        [DllImport(PKMDS_WIN32_DLL, CallingConvention = CallingConvention.Cdecl)]
        private static extern void GetPKMData_INTERNAL([In][Out] Pokemon pokemon, Save sav, int box, int slot);

        public static void GetPKMData([In][Out] ref Pokemon pokemon, Save sav, int box, int slot)
        {
            Pokemon pkm = new Pokemon();
            int size = Marshal.SizeOf(typeof(Pokemon));
            IntPtr pkmptr = Marshal.AllocHGlobal(size);
            Marshal.StructureToPtr(pkm, pkmptr, false);
            GetPKMData_INTERNAL(pkm, sav, box, slot);
            pokemon = pkm;
            Marshal.FreeHGlobal(pkmptr);
            pkmptr = IntPtr.Zero;
        }

        [DllImport(PKMDS_WIN32_DLL, CallingConvention = CallingConvention.Cdecl)]
        private static extern void GetSAVData_INTERNAL([In][Out] Save save, string savefile);

        public static void GetSAVData([In][Out] ref Save save, string savefile)
        {
            Save sav = new Save();
            int size = Marshal.SizeOf(typeof(Save));
            IntPtr savptr = Marshal.AllocHGlobal(size);
            Marshal.StructureToPtr(sav, savptr, false);
            GetSAVData_INTERNAL(sav, savefile);
            save = sav;
            Marshal.FreeHGlobal(savptr);
            savptr = IntPtr.Zero;
        }

        /*
         static void DisplayTestStructSimple_ByPointer()
{
  TestStructSimple test_struct_simple = new TestStructSimple();

  test_struct_simple.m_int01 = 100;

  int iSizeOfTestStructSimple = Marshal.SizeOf(typeof(TestStructSimple));
  IntPtr ptest_struct_simple = Marshal.AllocHGlobal(iSizeOfTestStructSimple);
  Marshal.StructureToPtr(test_struct_simple, ptest_struct_simple, false);

  DisplayTestStructSimple_ByPointer(ptest_struct_simple);

  Marshal.FreeHGlobal(ptest_struct_simple);
  ptest_struct_simple = IntPtr.Zero;
}
         */

    }

    //[StructLayout(LayoutKind.Sequential)]
    //public class UnencryptedData
    //{
    //    public UInt32 PID;
    //    private UInt16 runtime;
    //    private UInt16 checksum;
    //}

    //[StructLayout(LayoutKind.Sequential)]
    //public class BlockA
    //{
    //    public UInt16 Species;
    //    public UInt16 Item;
    //    public UInt16 TID;
    //    public UInt16 SID;
    //    public UInt32 EXP;
    //    public byte Tameness;
    //    public byte Ability;
    //    private byte Markings;
    //    public byte Language;
    //    public byte HPEV;
    //    public byte AttackEV;
    //    public byte DefenseEV;
    //    public byte SpeedEV;
    //    public byte SpAttackEV;
    //    public byte SpDefenseEV;
    //    public byte Cool;
    //    public byte Beauty;
    //    public byte Cute;
    //    public byte Smart;
    //    public byte Tough;
    //    public byte Sheen;
    //    private UInt16 SinnohRibbons1;
    //    private UInt16 UnovaRibbons;
    //}

    //[StructLayout(LayoutKind.Sequential)]
    //public class BlockB
    //{
    //    public UInt16 Move1;
    //    public UInt16 Move2;
    //    public UInt16 Move3;
    //    public UInt16 Move4;
    //    public byte Move1CurrentPP;
    //    public byte Move2CurrentPP;
    //    public byte Move3CurrentPP;
    //    public byte Move4CurrentPP;
    //    public byte Move1PPUp;
    //    public byte Move2PPUp;
    //    public byte Move3PPUp;
    //    public byte Move4PPUp;
    //    private UInt32 IVs;
    //    private UInt16 HoennRibbons1;
    //    private UInt16 HoennRibbons2;
    //    private byte FatefulEncounter;
    //    public byte Nature;
    //    private byte DreamWorldAbilityFlag;
    //    private byte unused;
    //    private UInt32 unknown;
    //}

    //[StructLayout(LayoutKind.Sequential)]
    //public class BlockC
    //{
    //    private UInt16 Nickname1;
    //    private UInt16 Nickname2;
    //    private UInt16 Nickname3;
    //    private UInt16 Nickname4;
    //    private UInt16 Nickname5;
    //    private UInt16 Nickname6;
    //    private UInt16 Nickname7;
    //    private UInt16 Nickname8;
    //    private UInt16 Nickname9;
    //    private UInt16 Nickname10;
    //    private UInt16 Nickname11;
    //    private byte unknown2;
    //    public byte Hometown;
    //    private UInt16 SinnohRibbons3;
    //    private UInt16 SinnohRibbons4;
    //    private UInt32 unused2;
    //}

    //[StructLayout(LayoutKind.Sequential)]
    //public class BlockD
    //{
    //    private UInt16 OTName1;
    //    private UInt16 OTName2;
    //    private UInt16 OTName3;
    //    private UInt16 OTName4;
    //    private UInt16 OTName5;
    //    private UInt16 OTName6;
    //    private UInt16 OTName7;
    //    private UInt16 OTName8;
    //    public byte EggYear;
    //    public byte EggMonth;
    //    public byte EggDay;
    //    public byte MetYear;
    //    public byte MetMonth;
    //    public byte MetDay;
    //    public UInt16 EggLocation;
    //    public UInt16 MetLocation;
    //    public byte PokeRus;
    //    public byte PokeBall;
    //    private byte MetLevel;
    //    public byte EncounterType;
    //    private UInt16 unused3;
    //}

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    public class Pokemon
    {
        // Unencrypted data
        public UInt32 PID;
        private UInt16 runtime;
        private UInt16 checksum;

        // Block A
        //public UInt16 Species;
        public Species.species Species;
        public UInt16 Item;
        public UInt16 TID;
        public UInt16 SID;
        public UInt32 EXP;
        public byte Tameness;
        public byte Ability;
        private byte Markings;
        public byte Language;
        public byte HPEV;
        public byte AttackEV;
        public byte DefenseEV;
        public byte SpeedEV;
        public byte SpAttackEV;
        public byte SpDefenseEV;
        public byte Cool;
        public byte Beauty;
        public byte Cute;
        public byte Smart;
        public byte Tough;
        public byte Sheen;
        private UInt16 SinnohRibbons1;
        private UInt16 UnovaRibbons;

        // Block B
        public UInt16 Move1;
        public UInt16 Move2;
        public UInt16 Move3;
        public UInt16 Move4;
        public byte Move1CurrentPP;
        public byte Move2CurrentPP;
        public byte Move3CurrentPP;
        public byte Move4CurrentPP;
        public byte Move1PPUp;
        public byte Move2PPUp;
        public byte Move3PPUp;
        public byte Move4PPUp;
        private UInt32 IVs;
        private UInt16 HoennRibbons1;
        private UInt16 HoennRibbons2;
        private byte FatefulEncounter;
        public byte Nature;
        private byte DreamWorldAbilityFlag;
        private byte unused;
        private UInt32 unknown;

        // Block C
        private UInt16 Nickname1;
        private UInt16 Nickname2;
        private UInt16 Nickname3;
        private UInt16 Nickname4;
        private UInt16 Nickname5;
        private UInt16 Nickname6;
        private UInt16 Nickname7;
        private UInt16 Nickname8;
        private UInt16 Nickname9;
        private UInt16 Nickname10;
        private UInt16 Nickname11;
        private byte unknown2;
        public byte Hometown;
        private UInt16 SinnohRibbons3;
        private UInt16 SinnohRibbons4;
        private UInt32 unused2;

        // Block D
        private UInt16 OTName1;
        private UInt16 OTName2;
        private UInt16 OTName3;
        private UInt16 OTName4;
        private UInt16 OTName5;
        private UInt16 OTName6;
        private UInt16 OTName7;
        private UInt16 OTName8;
        public byte EggYear;
        public byte EggMonth;
        public byte EggDay;
        public byte MetYear;
        public byte MetMonth;
        public byte MetDay;
        public UInt16 EggLocation;
        public UInt16 MetLocation;
        public byte PokeRus;
        public byte PokeBall;
        private byte MetLevel;
        public byte EncounterType;
        private UInt16 unused3;
    }

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    public class Save
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 0x80000)]
        public byte[] Data;
    }
}
