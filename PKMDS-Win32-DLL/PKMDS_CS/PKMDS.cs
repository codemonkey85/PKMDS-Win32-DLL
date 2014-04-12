using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
namespace PKMDS_CS
{
    public class PKMDS
    {
        #region Constants
        private const string PKMDS_WIN32_DLL = "PKMDS-Win32-DLL.dll";
        private const int LANG_ID = 9;
        private const int VERSION_GROUP = 11;
        private const int GENERATION = 5;
        private const int BUFF_SIZE = 955;
        private const int NICKLENGTH = 11;
        private const int OTLENGTH = 8;
        #endregion

        #region DBAccess
        [DllImport(PKMDS_WIN32_DLL, CallingConvention = CallingConvention.Cdecl)]
        public static extern void OpenDB(string dbfilename);

        [DllImport(PKMDS_WIN32_DLL, CallingConvention = CallingConvention.Cdecl)]
        public static extern void CloseDB();

        [DllImport(PKMDS_WIN32_DLL, CallingConvention = CallingConvention.Cdecl)]
        public static extern void OpenImgDB(string dbfilename);

        [DllImport(PKMDS_WIN32_DLL, CallingConvention = CallingConvention.Cdecl)]
        public static extern void CloseImgDB();
        #endregion

        [DllImport(PKMDS_WIN32_DLL, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.BStr)]
        public static extern string GetPKMName(int speciesid, int langid = LANG_ID);

        [DllImport(PKMDS_WIN32_DLL, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.BStr)]
        private static extern string GetPKMName_FromObj([In][Out] Pokemon pkm);

        [DllImport(PKMDS_WIN32_DLL, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.BStr)]
        private static extern string GetTrainerName_FromSav([In][Out] Save sav);

        [DllImport(PKMDS_WIN32_DLL, CallingConvention = CallingConvention.Cdecl)]
        private static extern void WritePokemonFile([In][Out] Pokemon pkm, string filename, bool encrypt = false);

        [DllImport(PKMDS_WIN32_DLL, CallingConvention = CallingConvention.Cdecl)]
        private static extern void WriteSaveFile([In][Out] Save sav, string filename);

        [DllImport(PKMDS_WIN32_DLL, CallingConvention = CallingConvention.Cdecl)]
        private static extern bool IsPKMShiny([In][Out] Pokemon pkm);

        [DllImport(PKMDS_WIN32_DLL, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Auto)]
        private static extern void SetTrainerName_FromSav_INTERNAL([In][Out] Save sav, string name, int namelength);

        private static void SetTrainerName_FromSav([In][Out] Save sav, string name)
        {
            SetTrainerName_FromSav_INTERNAL(sav, name, name.Length);
        }

        [DllImport(PKMDS_WIN32_DLL, CallingConvention = CallingConvention.Cdecl)]
        private static extern int GetTrainerTID_FromSav([In][Out] Save sav);

        [DllImport(PKMDS_WIN32_DLL, CallingConvention = CallingConvention.Cdecl)]
        private static extern int GetTrainerSID_FromSav([In][Out] Save sav);

        [DllImport(PKMDS_WIN32_DLL, CallingConvention = CallingConvention.Cdecl)]
        private static extern void SetTrainerTID_FromSav([In][Out] Save sav, int tid);

        [DllImport(PKMDS_WIN32_DLL, CallingConvention = CallingConvention.Cdecl)]
        private static extern int GetBoxWallpaper([In][Out] Save sav, int box);

        [DllImport(PKMDS_WIN32_DLL, CallingConvention = CallingConvention.Cdecl)]
        private static extern void SetBoxWallpaper([In][Out] Save sav, int box, int wallpaper);

        [DllImport(PKMDS_WIN32_DLL, CallingConvention = CallingConvention.Cdecl)]
        private static extern void SetTrainerSID_FromSav([In][Out] Save sav, int sid);

        [DllImport(PKMDS_WIN32_DLL, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.BStr)]
        private static extern string GetBoxName([In][Out] Save sav, int box);

        [DllImport(PKMDS_WIN32_DLL, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Auto)]
        private static extern void SetBoxName([In][Out] Save sav, int box, string name, int namelength);

        [DllImport(PKMDS_WIN32_DLL, CallingConvention = CallingConvention.Cdecl)]
        private static extern int GetPKMStat([In][Out] Save sav, int box, int slot, int stat);

        [DllImport(PKMDS_WIN32_DLL, CallingConvention = CallingConvention.Cdecl)]
        private static extern int GetPKMStat_FromObj([In][Out] Pokemon pkm, int stat);

        [DllImport(PKMDS_WIN32_DLL, CallingConvention = CallingConvention.Cdecl)]
        private static extern int GetPKMLevel([In][Out] Pokemon pkm);

        [DllImport(PKMDS_WIN32_DLL, CallingConvention = CallingConvention.Cdecl)]
        private static extern void SetPKMLevel([In][Out] Pokemon pkm, int level);

        [DllImport(PKMDS_WIN32_DLL, CallingConvention = CallingConvention.Cdecl)]
        private static extern int GetPKMSpeciesID([In][Out] Pokemon pkm);

        [DllImport(PKMDS_WIN32_DLL, CallingConvention = CallingConvention.Cdecl)]
        private static extern void SetPKMSpeciesID([In][Out] Pokemon pkm, int speciesid);

        [DllImport(PKMDS_WIN32_DLL, CallingConvention = CallingConvention.Cdecl)]
        private static extern int GetPartySize([In][Out] Save sav);

        [DllImport(PKMDS_WIN32_DLL, CallingConvention = CallingConvention.Cdecl)]
        private static extern void SetPartySize([In][Out] Save sav, int size);

        [DllImport(PKMDS_WIN32_DLL, CallingConvention = CallingConvention.Cdecl)]
        private static extern int GetCurrentBox([In][Out] Save sav);

        [DllImport(PKMDS_WIN32_DLL, CallingConvention = CallingConvention.Cdecl)]
        private static extern void SetCurrentBox([In][Out] Save sav, int box);

        [DllImport(PKMDS_WIN32_DLL, CallingConvention = CallingConvention.Cdecl)]
        private static extern int GetPKMMoveID([In][Out] Pokemon pokemon, int moveid);

        [DllImport(PKMDS_WIN32_DLL, CallingConvention = CallingConvention.Cdecl)]
        private static extern bool IsPKMModified([In][Out] Pokemon pokemon);

        [DllImport(PKMDS_WIN32_DLL, CallingConvention = CallingConvention.Cdecl)]
        private static extern void FixPokemonChecksum([In][Out] Pokemon pokemon);

        [DllImport(PKMDS_WIN32_DLL, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.BStr)]
        private static extern string GetItemName_INTERNAL(int itemid, int generation, int langid);

        public static string GetItemName(int itemid, int generation = GENERATION, int langid = LANG_ID)
        {
            return GetItemName_INTERNAL(itemid, generation, langid);
        }

        [DllImport(PKMDS_WIN32_DLL, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.BStr)]
        public static extern string GetMoveName(int moveid, int langid = LANG_ID);

        [DllImport(PKMDS_WIN32_DLL, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.BStr)]
        private static extern string GetMoveTypeName(int moveid, int langid = LANG_ID);

        private static unsafe System.Drawing.Image GetPic(IntPtr picdata, int size)
        {
            if (size == 0)
            {
                return null;
            }
            byte[] thedata = new byte[size];
            System.Runtime.InteropServices.Marshal.Copy(picdata, thedata, 0, size);
            System.IO.Stream picstream = new System.IO.MemoryStream(thedata);
            System.Drawing.Image pic = System.Drawing.Image.FromStream(picstream);
            return pic;
        }

        [DllImport(PKMDS_WIN32_DLL, CallingConvention = CallingConvention.Cdecl)]
        private static unsafe extern void GetPKMSprite_INTERNAL([In][Out] Pokemon pokemon, [In][Out] IntPtr* picdata, [In][Out] int* size, int generation);

        [DllImport(PKMDS_WIN32_DLL, CallingConvention = CallingConvention.Cdecl)]
        private static unsafe extern void GetPKMIcon_INTERNAL([In][Out] Pokemon pokemon, [In][Out] IntPtr* picdata, [In][Out] int* size, int generation);

        [DllImport(PKMDS_WIN32_DLL, CallingConvention = CallingConvention.Cdecl)]
        private static unsafe extern void GetTypePic_INTERNAL(int type, [In][Out] IntPtr* picdata, [In][Out] int* size);

        [DllImport(PKMDS_WIN32_DLL, CallingConvention = CallingConvention.Cdecl)]
        private static unsafe extern void GetShinyStar_INTERNAL([In][Out] IntPtr* picdata, [In][Out] int* size);

        [DllImport(PKMDS_WIN32_DLL, CallingConvention = CallingConvention.Cdecl)]
        private static unsafe extern void GetGenderPic_INTERNAL(int gender, [In][Out] IntPtr* picdata, [In][Out] int* size);

        [DllImport(PKMDS_WIN32_DLL, CallingConvention = CallingConvention.Cdecl)]
        private static unsafe extern void GetWallpaperImage_INTERNAL(int wallpaper, [In][Out] IntPtr* picdata, [In][Out] int* size);

        [DllImport(PKMDS_WIN32_DLL, CallingConvention = CallingConvention.Cdecl)]
        private static unsafe extern void GetItemImage_INTERNAL(int item, [In][Out] IntPtr* picdata, [In][Out] int* size);

        [DllImport(PKMDS_WIN32_DLL, CallingConvention = CallingConvention.Cdecl)]
        private static unsafe extern void GetMarkingImage_INTERNAL(int marking, bool marked, [In][Out] IntPtr* picdata, [In][Out] int* size);

        [DllImport(PKMDS_WIN32_DLL, CallingConvention = CallingConvention.Cdecl)]
        private static unsafe extern void GetBallPic_INTERNAL(int ball, [In][Out] IntPtr* picdata, [In][Out] int* size);

        [DllImport(PKMDS_WIN32_DLL, CallingConvention = CallingConvention.Cdecl)]
        private static unsafe extern void GetMoveCategoryImage_INTERNAL(int move, [In][Out] IntPtr* picdata, [In][Out] int* size);

        [DllImport(PKMDS_WIN32_DLL, CallingConvention = CallingConvention.Cdecl)]
        private static unsafe extern void GetPokerusImage_INTERNAL(int strain, int days, [In][Out] IntPtr* picdata, [In][Out] int* size);

        [DllImport(PKMDS_WIN32_DLL, CallingConvention = CallingConvention.Cdecl)]
        private static unsafe extern void GetRibbonImage_INTERNAL(string ribbon, bool hoenn, [In][Out] IntPtr* picdata, [In][Out] int* size);

        private static unsafe System.Drawing.Image GetPKMSprite([In][Out] Pokemon pokemon, int Generation = GENERATION)
        {
            IntPtr picdata = new IntPtr();
            int size = new int();
            GetPKMSprite_INTERNAL(pokemon, &picdata, &size, Generation);
            return GetPic(picdata, size);
        }
        private static unsafe System.Drawing.Image GetPKMIcon([In][Out] Pokemon pokemon, int Generation = GENERATION)
        {
            IntPtr picdata = new IntPtr();
            int size = new int();
            GetPKMIcon_INTERNAL(pokemon, &picdata, &size, Generation);
            return GetPic(picdata, size);
        }
        private static unsafe System.Drawing.Image GetTypePic(int type)
        {
            IntPtr picdata = new IntPtr();
            int size = new int();
            GetTypePic_INTERNAL(type, &picdata, &size);
            return GetPic(picdata, size);
        }

        private static unsafe System.Drawing.Image GetShinyStar()
        {
            IntPtr picdata = new IntPtr();
            int size = new int();
            GetShinyStar_INTERNAL(&picdata, &size);
            return GetPic(picdata, size);
        }

        private static unsafe System.Drawing.Image GetGenderPic(int gender)
        {
            IntPtr picdata = new IntPtr();
            int size = new int();
            GetGenderPic_INTERNAL(gender, &picdata, &size);
            return GetPic(picdata, size);
        }

        private static unsafe System.Drawing.Image GetWallpaperImage(int wallpaper)
        {
            IntPtr picdata = new IntPtr();
            int size = new int();
            GetWallpaperImage_INTERNAL(wallpaper, &picdata, &size);
            return GetPic(picdata, size);
        }

        private static unsafe System.Drawing.Image GetItemImage(int item)
        {
            IntPtr picdata = new IntPtr();
            int size = new int();
            GetItemImage_INTERNAL(item, &picdata, &size);
            return GetPic(picdata, size);
        }

        private static unsafe System.Drawing.Image GetMarkingImage(int marking, bool marked)
        {
            IntPtr picdata = new IntPtr();
            int size = new int();
            GetMarkingImage_INTERNAL(marking, marked, &picdata, &size);
            return GetPic(picdata, size);
        }

        private static unsafe System.Drawing.Image GetBallPic(int ball)
        {
            IntPtr picdata = new IntPtr();
            int size = new int();
            GetBallPic_INTERNAL(ball, &picdata, &size);
            return GetPic(picdata, size);
        }

        private static unsafe System.Drawing.Image GetMoveCategoryImage(int move)
        {
            IntPtr picdata = new IntPtr();
            int size = new int();
            GetMoveCategoryImage_INTERNAL(move, &picdata, &size);
            return GetPic(picdata, size);
        }

        private static unsafe System.Drawing.Image GetPokerusImage(int strain, int days)
        {
            IntPtr picdata = new IntPtr();
            int size = new int();
            GetPokerusImage_INTERNAL(strain, days, &picdata, &size);
            return GetPic(picdata, size);
        }

        private static unsafe System.Drawing.Image GetRibbonImage(string ribbon, bool hoenn)
        {
            IntPtr picdata = new IntPtr();
            int size = new int();
            GetRibbonImage_INTERNAL(ribbon, hoenn, &picdata, &size);
            return GetPic(picdata, size);
        }

        private static string[] GetPKMMoveNames([In][Out] Pokemon pkm, int langid = LANG_ID)
        {
            string[] moves = { "", "", "", "" };
            for (int move = 0; move < 4; move++)
            {
                moves[move] = GetMoveName(GetPKMMoveID(pkm, move), langid);
            }
            return moves;
        }

        private static string[] GetPKMMoveTypeNames([In][Out] Pokemon pkm, int langid = LANG_ID)
        {
            string[] moves = { "", "", "", "" };
            for (int move = 0; move < 4; move++)
            {
                moves[move] = GetMoveTypeName(GetPKMMoveID(pkm, move), langid);
            }
            return moves;
        }

        [DllImport(PKMDS_WIN32_DLL, CallingConvention = CallingConvention.Cdecl)]
        private static extern int GetPKMPID([In][Out] Pokemon pkm);

        [DllImport(PKMDS_WIN32_DLL, CallingConvention = CallingConvention.Cdecl)]
        private static extern void SetPKMPID([In][Out] Pokemon pkm, int pid);

        [DllImport(PKMDS_WIN32_DLL, CallingConvention = CallingConvention.Cdecl)]
        private static extern int GetPKMItemIndex([In][Out] Pokemon pkm);

        [DllImport(PKMDS_WIN32_DLL, CallingConvention = CallingConvention.Cdecl)]
        private static extern void SetPKMItemIndex([In][Out] Pokemon pkm, int item);

        [DllImport(PKMDS_WIN32_DLL, CallingConvention = CallingConvention.Cdecl)]
        private static extern int GetPKMTID([In][Out] Pokemon pkm);

        [DllImport(PKMDS_WIN32_DLL, CallingConvention = CallingConvention.Cdecl)]
        private static extern void SetPKMTID([In][Out] Pokemon pkm, int tid);

        [DllImport(PKMDS_WIN32_DLL, CallingConvention = CallingConvention.Cdecl)]
        private static extern int GetPKMSID([In][Out] Pokemon pkm);

        [DllImport(PKMDS_WIN32_DLL, CallingConvention = CallingConvention.Cdecl)]
        private static extern void SetPKMSID([In][Out] Pokemon pkm, int sid);

        [DllImport(PKMDS_WIN32_DLL, CallingConvention = CallingConvention.Cdecl)]
        private static extern int GetPKMEXP([In][Out] Pokemon pkm);

        [DllImport(PKMDS_WIN32_DLL, CallingConvention = CallingConvention.Cdecl)]
        private static extern void SetPKMEXP([In][Out] Pokemon pkm, int exp);

        [DllImport(PKMDS_WIN32_DLL, CallingConvention = CallingConvention.Cdecl)]
        private static extern int GetPKMTameness([In][Out] Pokemon pkm);

        [DllImport(PKMDS_WIN32_DLL, CallingConvention = CallingConvention.Cdecl)]
        private static extern void SetPKMTameness([In][Out] Pokemon pkm, int tameness);

        [DllImport(PKMDS_WIN32_DLL, CallingConvention = CallingConvention.Cdecl)]
        private static extern int GetPKMAbilityIndex([In][Out] Pokemon pkm);

        [DllImport(PKMDS_WIN32_DLL, CallingConvention = CallingConvention.Cdecl)]
        private static extern void SetPKMAbilityIndex([In][Out] Pokemon pkm, int ability);

        [DllImport(PKMDS_WIN32_DLL, CallingConvention = CallingConvention.Cdecl)]
        private static extern bool GetPKMMarking([In][Out] Pokemon pkm, int marking);

        [DllImport(PKMDS_WIN32_DLL, CallingConvention = CallingConvention.Cdecl)]
        private static extern void SetPKMMarking([In][Out] Pokemon pkm, int marking, bool marked);

        [DllImport(PKMDS_WIN32_DLL, CallingConvention = CallingConvention.Cdecl)]
        private static extern int GetPKMLanguage([In][Out] Pokemon pkm);

        [DllImport(PKMDS_WIN32_DLL, CallingConvention = CallingConvention.Cdecl)]
        private static extern void SetPKMLanguage([In][Out] Pokemon pkm, int language);

        [DllImport(PKMDS_WIN32_DLL, CallingConvention = CallingConvention.Cdecl)]
        private static extern int GetPKMEV([In][Out] Pokemon pkm, int evindex);

        [DllImport(PKMDS_WIN32_DLL, CallingConvention = CallingConvention.Cdecl)]
        private static extern void SetPKMEV([In][Out] Pokemon pkm, int evindex, int ev);

        [DllImport(PKMDS_WIN32_DLL, CallingConvention = CallingConvention.Cdecl)]
        private static extern int GetPKMIV([In][Out] Pokemon pkm, int evindex);

        [DllImport(PKMDS_WIN32_DLL, CallingConvention = CallingConvention.Cdecl)]
        private static extern void SetPKMIV([In][Out] Pokemon pkm, int ivindex, int iv);

        [DllImport(PKMDS_WIN32_DLL, CallingConvention = CallingConvention.Cdecl)]
        private static extern int GetPKMContest([In][Out] Pokemon pkm, int contestindex);

        [DllImport(PKMDS_WIN32_DLL, CallingConvention = CallingConvention.Cdecl)]
        private static extern void SetPKMContest([In][Out] Pokemon pkm, int contestindex, int contest);

        [DllImport(PKMDS_WIN32_DLL, CallingConvention = CallingConvention.Cdecl)]
        private static extern int GetPKMMovePP([In][Out] Pokemon pkm, int move);

        [DllImport(PKMDS_WIN32_DLL, CallingConvention = CallingConvention.Cdecl)]
        private static extern void SetPKMMovePP([In][Out] Pokemon pkm, int move, int pp);

        [DllImport(PKMDS_WIN32_DLL, CallingConvention = CallingConvention.Cdecl)]
        private static extern int GetPKMMovePPUp([In][Out] Pokemon pkm, int move);

        [DllImport(PKMDS_WIN32_DLL, CallingConvention = CallingConvention.Cdecl)]
        private static extern void SetPKMMovePPUp([In][Out] Pokemon pkm, int move, int ppup);

        [DllImport(PKMDS_WIN32_DLL, CallingConvention = CallingConvention.Cdecl)]
        private static extern bool GetPKMIsEgg([In][Out] Pokemon pkm);

        [DllImport(PKMDS_WIN32_DLL, CallingConvention = CallingConvention.Cdecl)]
        private static extern void SetPKMIsEgg([In][Out] Pokemon pkm, bool isegg);

        [DllImport(PKMDS_WIN32_DLL, CallingConvention = CallingConvention.Cdecl)]
        private static extern bool GetPKMIsNicknamed([In][Out] Pokemon pkm);

        [DllImport(PKMDS_WIN32_DLL, CallingConvention = CallingConvention.Cdecl)]
        private static extern void SetPKMIsNicknamed([In][Out] Pokemon pkm, bool isnicknamed);

        [DllImport(PKMDS_WIN32_DLL, CallingConvention = CallingConvention.Cdecl)]
        private static extern bool GetPKMFateful([In][Out] Pokemon pkm);

        [DllImport(PKMDS_WIN32_DLL, CallingConvention = CallingConvention.Cdecl)]
        private static extern void SetPKMFateful([In][Out] Pokemon pkm, bool isfateful);

        [DllImport(PKMDS_WIN32_DLL, CallingConvention = CallingConvention.Cdecl)]
        private static extern int GetPKMGender([In][Out] Pokemon pkm);

        [DllImport(PKMDS_WIN32_DLL, CallingConvention = CallingConvention.Cdecl)]
        private static extern void SetPKMGender([In][Out] Pokemon pkm, int gender);

        [DllImport(PKMDS_WIN32_DLL, CallingConvention = CallingConvention.Cdecl)]
        private static extern int GetPKMForm([In][Out] Pokemon pkm);

        [DllImport(PKMDS_WIN32_DLL, CallingConvention = CallingConvention.Cdecl)]
        private static extern void SetPKMForm([In][Out] Pokemon pkm, int form);

        [DllImport(PKMDS_WIN32_DLL, CallingConvention = CallingConvention.Cdecl)]
        private static extern int GetPKMNature([In][Out] Pokemon pkm);

        [DllImport(PKMDS_WIN32_DLL, CallingConvention = CallingConvention.Cdecl)]
        private static extern void SetPKMNature([In][Out] Pokemon pkm, int nature);

        [DllImport(PKMDS_WIN32_DLL, CallingConvention = CallingConvention.Cdecl)]
        private static extern bool GetPKMDWAbility([In][Out] Pokemon pkm);

        [DllImport(PKMDS_WIN32_DLL, CallingConvention = CallingConvention.Cdecl)]
        private static extern void SetPKMDWAbility([In][Out] Pokemon pkm, bool hasdwability);

        [DllImport(PKMDS_WIN32_DLL, CallingConvention = CallingConvention.Cdecl)]
        private static extern bool GetPKMNsPokemon([In][Out] Pokemon pkm);

        [DllImport(PKMDS_WIN32_DLL, CallingConvention = CallingConvention.Cdecl)]
        private static extern void SetPKMNsPokemon([In][Out] Pokemon pkm, bool isnspokemon);

        [DllImport(PKMDS_WIN32_DLL, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Auto)]
        [return: MarshalAs(UnmanagedType.BStr)]
        private static extern string GetPKMNickname([In][Out] Pokemon pkm);

        [DllImport(PKMDS_WIN32_DLL, CallingConvention = CallingConvention.Cdecl)]
        private static extern void SetPKMNickname([In][Out] Pokemon pkm, string nickname, int nicknamelength);

        [DllImport(PKMDS_WIN32_DLL, CallingConvention = CallingConvention.Cdecl)]
        private static extern int GetPKMHometown([In][Out] Pokemon pkm);

        [DllImport(PKMDS_WIN32_DLL, CallingConvention = CallingConvention.Cdecl)]
        private static extern void SetPKMHometown([In][Out] Pokemon pkm, int hometown);

        [DllImport(PKMDS_WIN32_DLL, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Auto)]
        [return: MarshalAs(UnmanagedType.BStr)]
        private static extern string GetPKMOTName([In][Out] Pokemon pkm);

        [DllImport(PKMDS_WIN32_DLL, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Auto)]
        private static extern void SetPKMOTName([In][Out] Pokemon pkm, string otname, int otnamelength);

        [DllImport(PKMDS_WIN32_DLL, CallingConvention = CallingConvention.Cdecl)]
        private static extern int GetPKMEggYear([In][Out] Pokemon pkm);

        [DllImport(PKMDS_WIN32_DLL, CallingConvention = CallingConvention.Cdecl)]
        private static extern void SetPKMEggYear([In][Out] Pokemon pkm, int year);

        [DllImport(PKMDS_WIN32_DLL, CallingConvention = CallingConvention.Cdecl)]
        private static extern int GetPKMEggMonth([In][Out] Pokemon pkm);

        [DllImport(PKMDS_WIN32_DLL, CallingConvention = CallingConvention.Cdecl)]
        private static extern void SetPKMEggMonth([In][Out] Pokemon pkm, int month);

        [DllImport(PKMDS_WIN32_DLL, CallingConvention = CallingConvention.Cdecl)]
        private static extern int GetPKMEggDay([In][Out] Pokemon pkm);

        [DllImport(PKMDS_WIN32_DLL, CallingConvention = CallingConvention.Cdecl)]
        private static extern void SetPKMEggDay([In][Out] Pokemon pkm, int day);

        [DllImport(PKMDS_WIN32_DLL, CallingConvention = CallingConvention.Cdecl)]
        private static extern int GetPKMMetYear([In][Out] Pokemon pkm);

        [DllImport(PKMDS_WIN32_DLL, CallingConvention = CallingConvention.Cdecl)]
        private static extern void SetPKMMetYear([In][Out] Pokemon pkm, int year);

        [DllImport(PKMDS_WIN32_DLL, CallingConvention = CallingConvention.Cdecl)]
        private static extern int GetPKMMetMonth([In][Out] Pokemon pkm);

        [DllImport(PKMDS_WIN32_DLL, CallingConvention = CallingConvention.Cdecl)]
        private static extern void SetPKMMetMonth([In][Out] Pokemon pkm, int month);

        [DllImport(PKMDS_WIN32_DLL, CallingConvention = CallingConvention.Cdecl)]
        private static extern int GetPKMMetDay([In][Out] Pokemon pkm);

        [DllImport(PKMDS_WIN32_DLL, CallingConvention = CallingConvention.Cdecl)]
        private static extern void SetPKMMetDay([In][Out] Pokemon pkm, int day);

        [DllImport(PKMDS_WIN32_DLL, CallingConvention = CallingConvention.Cdecl)]
        private static extern int GetPKMEggLocation([In][Out] Pokemon pkm);

        [DllImport(PKMDS_WIN32_DLL, CallingConvention = CallingConvention.Cdecl)]
        private static extern void SetPKMEggLocation([In][Out] Pokemon pkm, int location);

        [DllImport(PKMDS_WIN32_DLL, CallingConvention = CallingConvention.Cdecl)]
        private static extern int GetPKMMetLocation([In][Out] Pokemon pkm);

        [DllImport(PKMDS_WIN32_DLL, CallingConvention = CallingConvention.Cdecl)]
        private static extern void SetPKMMetLocation([In][Out] Pokemon pkm, int location);

        [DllImport(PKMDS_WIN32_DLL, CallingConvention = CallingConvention.Cdecl)]
        private static extern int GetPKMPokerusStrain([In][Out] Pokemon pkm);

        [DllImport(PKMDS_WIN32_DLL, CallingConvention = CallingConvention.Cdecl)]
        private static extern void SetPKMPokerusStrain([In][Out] Pokemon pkm, int strain);

        [DllImport(PKMDS_WIN32_DLL, CallingConvention = CallingConvention.Cdecl)]
        private static extern int GetPKMPokerusDays([In][Out] Pokemon pkm);

        [DllImport(PKMDS_WIN32_DLL, CallingConvention = CallingConvention.Cdecl)]
        private static extern void SetPKMPokerusDays([In][Out] Pokemon pkm, int days);

        [DllImport(PKMDS_WIN32_DLL, CallingConvention = CallingConvention.Cdecl)]
        private static extern int GetPKMBall([In][Out] Pokemon pkm);

        [DllImport(PKMDS_WIN32_DLL, CallingConvention = CallingConvention.Cdecl)]
        private static extern void SetPKMBall([In][Out] Pokemon pkm, int ball);

        [DllImport(PKMDS_WIN32_DLL, CallingConvention = CallingConvention.Cdecl)]
        private static extern int GetPKMMetLevel([In][Out] Pokemon pkm);

        [DllImport(PKMDS_WIN32_DLL, CallingConvention = CallingConvention.Cdecl)]
        private static extern void SetPKMMetLevel([In][Out] Pokemon pkm, int level);

        [DllImport(PKMDS_WIN32_DLL, CallingConvention = CallingConvention.Cdecl)]
        private static extern int GetPKMOTGender([In][Out] Pokemon pkm);

        [DllImport(PKMDS_WIN32_DLL, CallingConvention = CallingConvention.Cdecl)]
        private static extern void SetPKMOTGender([In][Out] Pokemon pkm, int gender);

        [DllImport(PKMDS_WIN32_DLL, CallingConvention = CallingConvention.Cdecl)]
        private static extern int GetPKMEncounter([In][Out] Pokemon pkm);

        [DllImport(PKMDS_WIN32_DLL, CallingConvention = CallingConvention.Cdecl)]
        private static extern void SetPKMEncounter([In][Out] Pokemon pkm, int encounter);

        [DllImport(PKMDS_WIN32_DLL, CallingConvention = CallingConvention.Cdecl)]
        private static extern void GetPKMData_INTERNAL([In][Out] Pokemon pokemon, [In][Out] Save sav, int box, int slot);

        [DllImport(PKMDS_WIN32_DLL, CallingConvention = CallingConvention.Cdecl)]
        private static extern void GetPartyPKMData_INTERNAL([In][Out] PartyPokemon pokemon, [In][Out] Save sav, int slot);

        [DllImport(PKMDS_WIN32_DLL, CallingConvention = CallingConvention.Cdecl)]
        private static extern void GetPKMDataFromFile_INTERNAL([In][Out] Pokemon pokemon, string filename);

        private static void GetPKMData([In][Out] ref Pokemon pokemon, [In][Out] Save sav, int box, int slot)
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

        private static void GetPartyPKMData([In][Out] ref PartyPokemon pokemon, [In][Out] Save sav, int slot)
        {
            PartyPokemon pkm = new PartyPokemon();
            int size = Marshal.SizeOf(typeof(PartyPokemon));
            IntPtr pkmptr = Marshal.AllocHGlobal(size);
            Marshal.StructureToPtr(pkm, pkmptr, false);
            GetPartyPKMData_INTERNAL(pkm, sav, slot);
            pokemon = pkm;
            Marshal.FreeHGlobal(pkmptr);
            pkmptr = IntPtr.Zero;
        }

        [DllImport(PKMDS_WIN32_DLL, CallingConvention = CallingConvention.Cdecl)]
        private static extern void SetPKMData_INTERNAL([In][Out] Pokemon pokemon, [In][Out] Save sav, int box, int slot);

        [DllImport(PKMDS_WIN32_DLL, CallingConvention = CallingConvention.Cdecl)]
        private static extern void SetPartyPKMData_INTERNAL([In][Out] PartyPokemon pokemon, [In][Out] Save sav, int slot);

        public static void SetPKMData([In][Out] Pokemon pokemon, [In][Out] Save sav, int box, int slot)
        {
            SetPKMData_INTERNAL(pokemon, sav, box, slot);
        }

        public static void SetPartyPKMData([In][Out] PartyPokemon pokemon, [In][Out] Save sav, int slot)
        {
            SetPartyPKMData_INTERNAL(pokemon, sav, slot);
        }

        [DllImport(PKMDS_WIN32_DLL, CallingConvention = CallingConvention.Cdecl)]
        private static extern void GetSAVData_INTERNAL([In][Out] Save save, string savefile);

        public static Save ReadSaveFile(string savefile)
        {
            Save sav = new Save();
            Save save = new Save();
            int size = Marshal.SizeOf(typeof(Save));
            IntPtr savptr = Marshal.AllocHGlobal(size);
            Marshal.StructureToPtr(sav, savptr, false);
            GetSAVData_INTERNAL(sav, savefile);
            save = sav;
            Marshal.FreeHGlobal(savptr);
            savptr = IntPtr.Zero;
            return save;
        }

        public static Pokemon ReadPokemonFile(string pokemonfile)
        {
            Pokemon pkm = new Pokemon();
            Pokemon pokemon = new Pokemon();
            int size = Marshal.SizeOf(typeof(Pokemon));
            IntPtr savptr = Marshal.AllocHGlobal(size);
            Marshal.StructureToPtr(pkm, savptr, false);
            GetPKMDataFromFile_INTERNAL(pkm, pokemonfile);
            pokemon = pkm;
            Marshal.FreeHGlobal(savptr);
            savptr = IntPtr.Zero;
            return pokemon;
        }

        public class Item
        {
            public Item()
            {
                this.itemid = 0;
            }
            public Item(int itemid)
            {
                this.itemid = itemid;
            }
            private int itemid;
            public int ItemID
            {
                get
                {
                    return itemid;
                }
                set
                {
                    itemid = value;
                }
            }
            public string ItemName
            {
                get
                {
                    string name = PKMDS.GetItemName(this.itemid);
                    if (name == null)
                    {
                        return "";
                    }
                    else
                    {
                        return name;
                    }
                }
            }
            public System.Drawing.Image ItemImage
            {
                get
                {
                    if (itemid == 0)
                    {
                        return null;
                    }
                    else
                    {
                        return PKMDS.GetItemImage(this.itemid);
                    }
                }
            }
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
        public class Pokemon
        {
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 136)]
            private byte[] Data;
            public string SpeciesName
            {
                get
                {
                    return PKMDS.GetPKMName_FromObj(this);
                }
            }
            public System.Drawing.Image Sprite
            {
                get
                {
                    return PKMDS.GetPKMSprite(this);
                }
            }
            public int[] GetStats
            {
                get
                {
                    int[] ret = new int[6];
                    for (int stat = 0; stat < ret.Length; stat++)
                    {
                        ret[stat] = GetPKMStat_FromObj(this, stat + 1);
                    }
                    return ret;
                }
            }
            public int Level
            {
                get
                {
                    return GetPKMLevel(this);
                }
                set
                {
                    SetPKMLevel(this, value);
                }
            }
            public int SpeciesID
            {
                get
                {
                    return GetPKMSpeciesID(this);
                }
                set
                {
                    SetPKMSpeciesID(this, value);
                }
            }
            public void WriteToFile(string FileName, bool encrypt = false)
            {
                WritePokemonFile(this, FileName, encrypt);
            }
            public int PID
            {
                get
                {
                    return GetPKMPID(this);
                }
                set
                {
                    SetPKMPID(this, value);
                }
            }
            public int ItemID
            {
                get
                {
                    return GetPKMItemIndex(this);
                }
                set
                {
                    SetPKMItemIndex(this, value);
                }
            }
            public int TID
            {
                get
                {
                    return GetPKMTID(this);
                }
                set
                {
                    SetPKMTID(this, value);
                }
            }
            public int SID
            {
                get
                {
                    return GetPKMSID(this);
                }
                set
                {
                    SetPKMSID(this, value);
                }
            }
            public int EXP
            {
                get
                {
                    return GetPKMEXP(this);
                }
                set
                {
                    SetPKMEXP(this, value);
                }
            }
            public int Tameness
            {
                get
                {
                    return GetPKMTameness(this);
                }
                set
                {
                    SetPKMTameness(this, value);
                }
            }
            public int AbilityID
            {
                get
                {
                    return GetPKMAbilityIndex(this);
                }
                set
                {
                    SetPKMAbilityIndex(this, value);
                }
            }
            public bool GetMarking(int marking)
            {
                return GetPKMMarking(this, marking);
            }
            public void SetMarking(int marking, bool marked)
            {
                SetPKMMarking(this, marking, marked);
            }
            public int LanguageID
            {
                get
                {
                    return GetPKMLanguage(this);
                }
                set
                {
                    SetPKMLanguage(this, value);
                }
            }
            public int GetEV(int evindex)
            {
                return GetPKMEV(this, evindex);
            }
            public void SetEV(int evindex, int ev)
            {
                SetPKMEV(this, evindex, ev);
            }
            public int GetIV(int ivindex)
            {
                return GetPKMEV(this, ivindex);
            }
            public void SetIV(int ivindex, int iv)
            {
                SetPKMIV(this, ivindex, iv);
            }
            public int GetContest(int contestindex)
            {
                return GetPKMContest(this, contestindex);
            }
            public void SetContest(int contestindex, int contest)
            {
                SetPKMContest(this, contestindex, contest);
            }
            public int GetMovePP(int move)
            {
                return GetPKMMovePP(this, move);
            }
            public void SetMovePP(int move, int pp)
            {
                SetPKMMovePP(this, move, pp);
            }
            public int GetMovePPUp(int move)
            {
                return GetPKMMovePPUp(this, move);
            }
            public void SetMovePPUp(int move, int ppup)
            {
                SetPKMMovePPUp(this, move, ppup);
            }
            public bool IsEgg
            {
                get
                {
                    return GetPKMIsEgg(this);
                }
                set
                {
                    SetPKMIsEgg(this, value);
                }
            }
            public bool IsNicknamed
            {
                get
                {
                    return GetPKMIsNicknamed(this);
                }
                set
                {
                    SetPKMIsNicknamed(this, value);
                }
            }
            public bool IsFateful
            {
                get
                {
                    return GetPKMFateful(this);
                }
                set
                {
                    SetPKMFateful(this, value);
                }
            }
            public int GenderID
            {
                get
                {
                    return GetPKMGender(this);
                }
                set
                {
                    SetPKMGender(this, value);
                }
            }
            public int FormID
            {
                get
                {
                    return GetPKMForm(this);
                }
                set
                {
                    SetPKMForm(this, value);
                }
            }
            public int NatureID
            {
                get
                {
                    return GetPKMNature(this);
                }
                set
                {
                    SetPKMNature(this, value);
                }
            }
            public bool HasDWAbility
            {
                get
                {
                    return GetPKMDWAbility(this);
                }
                set
                {
                    SetPKMDWAbility(this, value);
                }
            }
            public bool IsNsPokemon
            {
                get
                {
                    return GetPKMNsPokemon(this);
                }
                set
                {
                    SetPKMNsPokemon(this, value);
                }
            }
            public string Nickname
            {
                get
                {
                    return GetPKMNickname(this);
                }
                set
                {
                    SetPKMNickname(this, value, value.Length);
                }
            }
            public int HometownID
            {
                get
                {
                    return GetPKMHometown(this);
                }
                set
                {
                    SetPKMHometown(this, value);
                }
            }
            public string OTName
            {
                get
                {
                    return GetPKMOTName(this);
                }
                set
                {
                    SetPKMOTName(this, value, value.Length);
                }
            }
            public DateTime EggDate
            {
                get
                {
                    return new DateTime(GetPKMEggYear(this), GetPKMEggMonth(this), GetPKMEggDay(this));
                }
                set
                {
                    SetPKMEggYear(this, value.Year);
                    SetPKMEggMonth(this, value.Month);
                    SetPKMEggDay(this, value.Day);
                }
            }
            public DateTime MetDate
            {
                get
                {
                    return new DateTime(GetPKMMetYear(this), GetPKMMetMonth(this), GetPKMMetDay(this));
                }
                set
                {
                    SetPKMMetYear(this, value.Year);
                    SetPKMMetMonth(this, value.Month);
                    SetPKMMetDay(this, value.Day);
                }
            }
            public int EggLocationID
            {
                get
                {
                    return GetPKMEggLocation(this);
                }
                set
                {
                    SetPKMEggLocation(this, value);
                }
            }
            public int MetLocationID
            {
                get
                {
                    return GetPKMMetLocation(this);
                }
                set
                {
                    SetPKMMetLocation(this, value);
                }
            }
            public int PokerusStrain
            {
                get
                {
                    return GetPKMPokerusStrain(this);
                }
                set
                {
                    SetPKMPokerusStrain(this, value);
                }
            }
            public int PokerusDays
            {
                get
                {
                    return GetPKMPokerusDays(this);
                }
                set
                {
                    SetPKMPokerusDays(this, value);
                }
            }
            public int BallID
            {
                get
                {
                    return GetPKMBall(this);
                }
                set
                {
                    SetPKMBall(this, value);
                }
            }
            public int MetLevel
            {
                get
                {
                    return GetPKMMetLevel(this);
                }
                set
                {
                    SetPKMMetLevel(this, value);
                }
            }
            public int OTGenderID
            {
                get
                {
                    return GetPKMOTGender(this);
                }
                set
                {
                    SetPKMOTGender(this, value);
                }
            }
            public int EncounterID
            {
                get
                {
                    return GetPKMEncounter(this);
                }
                set
                {
                    SetPKMEncounter(this, value);
                }
            }
            public bool IsModified
            {
                get
                {
                    return IsPKMModified(this);
                }
            }
            public void FixChecksum()
            {
                FixPokemonChecksum(this);
            }
            public System.Drawing.Image Icon
            {
                get
                {
                    return PKMDS.GetPKMIcon(this);
                }
            }
            public bool IsShiny
            {
                get
                {
                    return PKMDS.IsPKMShiny(this);
                }
            }
            public System.Drawing.Image GetTypePic(int type)
            {
                if ((type == 1) | (type == 2))
                {
                    return PKMDS.GetTypePic(type);
                }
                else
                {
                    return PKMDS.GetTypePic(1);
                }
            }
            public System.Drawing.Image ShinyIcon
            {
                get
                {
                    if (IsShiny)
                    {
                        return GetShinyStar();
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            public System.Drawing.Image GenderIcon
            {
                get
                {
                    return PKMDS.GetGenderPic(this.GenderID);
                }
            }
            public System.Drawing.Image ItemPic
            {
                get
                {
                    return PKMDS.GetItemImage(this.ItemID);
                }
            }
            public System.Drawing.Image GetMarkingImage(int marking)
            {
                return PKMDS.GetMarkingImage(marking, this.GetMarking(marking));
            }
            public System.Drawing.Image BallPic
            {
                get
                {
                    return PKMDS.GetBallPic(this.BallID);
                }
            }
            public System.Drawing.Image MoveCategoryPic(int move)
            {
                return PKMDS.GetMoveCategoryImage(move);
            }
            public System.Drawing.Image PokerusIcon
            {
                get
                {
                    return PKMDS.GetPokerusImage(this.PokerusStrain, this.PokerusDays);
                }
            }
            //public System.Drawing.Image RibbonPic
            //{
            //    get
            //    {
            //        return PKMDS.GetRibbonImage(this);
            //    }
            //}
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
        public class PartyPokemon //: Pokemon
        {
            public PartyPokemon()
            {
                this.PokemonData = new PKMDS.Pokemon();
            }
            public Pokemon PokemonData;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 84)]
            private byte[] PartyData;
            public void WriteToFile(string FileName, bool encrypt = false)
            {
                //WritePokemonFile(this, FileName, encrypt);
            }
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
        public class Save
        {
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 0x80000)]
            private byte[] Data;
            public string TrainerName
            {
                get
                {
                    return GetTrainerName_FromSav(this);
                }
                set
                {
                    SetTrainerName_FromSav(this, value);
                }
            }
            public int TID
            {
                get
                {
                    return GetTrainerTID_FromSav(this);
                }
                set
                {
                    SetTrainerTID_FromSav(this, value);
                }
            }
            public int SID
            {
                get
                {
                    return GetTrainerSID_FromSav(this);
                }
                set
                {
                    SetTrainerSID_FromSav(this, value);
                }
            }
            public string GetBoxName(int Box)
            {
                return PKMDS.GetBoxName(this, Box);
            }
            public void SetBoxName(int Box, string Name)
            {
                PKMDS.SetBoxName(this, Box, Name, Name.Length);
            }
            public int GetBoxWallpaperIndex(int Box)
            {
                return PKMDS.GetBoxWallpaper(this, Box);
            }
            public void SetBoxWallpaperIndex(int Box, int Wallpaper)
            {
                PKMDS.SetBoxWallpaper(this, Box, Wallpaper);
            }
            public System.Drawing.Image GetBoxWallpaper(int box)
            {
                return GetWallpaperImage(GetBoxWallpaperIndex(box));
            }
            public void WriteToFile(string FileName)
            {
                WriteSaveFile(this, FileName);
            }
            public Pokemon GetStoredPokemon(int Box, int Slot)
            {
                Pokemon pkm = new Pokemon();
                GetPKMData(ref pkm, this, Box, Slot);
                return pkm;
            }
            public void SetStoredPokemon(Pokemon pokemon, int Box, int Slot)
            {
                SetPKMData(pokemon, this, Box, Slot);
            }
            public PartyPokemon GetPartyPokemon(int Slot)
            {
                PartyPokemon pkm = new PartyPokemon();
                GetPartyPKMData(ref pkm, this, Slot);
                return pkm;
            }
            public void SetPartyPokemon(PartyPokemon pokemon, int Slot)
            {
                SetPartyPKMData(pokemon, this, Slot);
            }
            public int PartySize
            {
                get
                {
                    return GetPartySize(this);
                }
                set
                {
                    SetPartySize(this, value);
                }
            }
            public int CurrentBox
            {
                get
                {
                    return GetCurrentBox(this);
                }
                set
                {
                    SetCurrentBox(this, value);
                }
            }
        }
    }
}
