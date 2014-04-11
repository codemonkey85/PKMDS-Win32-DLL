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
        private static extern string GetPKMName(int speciesid, int langid = LANG_ID);

        [DllImport(PKMDS_WIN32_DLL, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.BStr)]
        private static extern string GetPKMName_FromObj(Pokemon pkm);

        [DllImport(PKMDS_WIN32_DLL, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.BStr)]
        private static extern string GetTrainerName_FromSav(Save sav);

        [DllImport(PKMDS_WIN32_DLL, CallingConvention = CallingConvention.Cdecl)]
        private static extern void WritePokemonFile(Pokemon pkm, string filename, bool encrypt = false);

        [DllImport(PKMDS_WIN32_DLL, CallingConvention = CallingConvention.Cdecl)]
        public static extern void WriteSaveFile(Save sav, string filename);

        [DllImport(PKMDS_WIN32_DLL, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Auto)]
        private static extern void SetTrainerName_FromSav_INTERNAL([In][Out] Save sav, string name, int namelength);

        private static void SetTrainerName_FromSav(/*[In][Out]*/ Save sav, string name)
        {
            SetTrainerName_FromSav_INTERNAL(sav, name, name.Length);
        }

        [DllImport(PKMDS_WIN32_DLL, CallingConvention = CallingConvention.Cdecl)]
        private static extern int GetTrainerTID_FromSav(Save sav);

        [DllImport(PKMDS_WIN32_DLL, CallingConvention = CallingConvention.Cdecl)]
        private static extern int GetTrainerSID_FromSav(Save sav);

        [DllImport(PKMDS_WIN32_DLL, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.BStr)]
        private static extern string GetBoxName(Save sav, int box);

        [DllImport(PKMDS_WIN32_DLL, CallingConvention = CallingConvention.Cdecl)]
        private static extern int GetPKMStat(Save sav, int box, int slot, int stat);

        [DllImport(PKMDS_WIN32_DLL, CallingConvention = CallingConvention.Cdecl)]
        private static extern int GetPKMStat_FromObj(Pokemon pkm, int stat);

        [DllImport(PKMDS_WIN32_DLL, CallingConvention = CallingConvention.Cdecl)]
        private static extern int GetPKMLevel(Pokemon pkm);

        [DllImport(PKMDS_WIN32_DLL, CallingConvention = CallingConvention.Cdecl)]
        private static extern void SetPKMLevel([In][Out] Pokemon pkm, int level);

        [DllImport(PKMDS_WIN32_DLL, CallingConvention = CallingConvention.Cdecl)]
        private static extern int GetPKMSpeciesID(Pokemon pkm);

        [DllImport(PKMDS_WIN32_DLL, CallingConvention = CallingConvention.Cdecl)]
        private static extern void SetPKMSpeciesID([In][Out] Pokemon pkm, int speciesid);

        [DllImport(PKMDS_WIN32_DLL, CallingConvention = CallingConvention.Cdecl)]
        private static extern int GetPKMMoveID(Pokemon pokemon, int moveid);

        [DllImport(PKMDS_WIN32_DLL, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.BStr)]
        private static extern string GetItemName(int itemid, int generation, int langid = LANG_ID);

        [DllImport(PKMDS_WIN32_DLL, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.BStr)]
        private static extern string GetMoveName(int moveid, int langid = LANG_ID);

        [DllImport(PKMDS_WIN32_DLL, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.BStr)]
        private static extern string GetMoveTypeName(int moveid, int langid = LANG_ID);

        private static unsafe System.Drawing.Image GetPic(IntPtr picdata, int size)
        {
            byte[] thedata = new byte[size];
            System.Runtime.InteropServices.Marshal.Copy(picdata, thedata, 0, size);
            System.IO.Stream picstream = new System.IO.MemoryStream(thedata);
            System.Drawing.Image pic = System.Drawing.Image.FromStream(picstream);
            return pic;
        }

        [DllImport(PKMDS_WIN32_DLL, CallingConvention = CallingConvention.Cdecl)]
        private static unsafe extern void GetPKMSprite_INTERNAL(Pokemon pokemon, [In][Out] IntPtr* picdata, [In][Out] int* size, int generation);

        [DllImport(PKMDS_WIN32_DLL, CallingConvention = CallingConvention.Cdecl)]
        private static unsafe extern void GetPKMIcon_INTERNAL(Pokemon pokemon, [In][Out] IntPtr* picdata, [In][Out] int* size, int generation);

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

        private static unsafe System.Drawing.Image GetPKMSprite(Pokemon pokemon, int Generation = GENERATION)
        {
            IntPtr picdata = new IntPtr();
            int size = new int();
            GetPKMSprite_INTERNAL(pokemon, &picdata, &size, Generation);
            return GetPic(picdata, size);
        }
        private static unsafe System.Drawing.Image GetPKMIcon(Pokemon pokemon, int Generation = GENERATION)
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

        private static string[] GetPKMMoveNames(Pokemon pkm, int langid = LANG_ID)
        {
            string[] moves = { "", "", "", "" };
            for (int move = 0; move < 4; move++)
            {
                moves[move] = GetMoveName(GetPKMMoveID(pkm, move), langid);
            }
            return moves;
        }

        private static string[] GetPKMMoveTypeNames(Pokemon pkm, int langid = LANG_ID)
        {
            string[] moves = { "", "", "", "" };
            for (int move = 0; move < 4; move++)
            {
                moves[move] = GetMoveTypeName(GetPKMMoveID(pkm, move), langid);
            }
            return moves;
        }

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
        private static extern void SetPKMData_INTERNAL([In][Out] Pokemon pokemon, Save sav, int box, int slot);

        public static void SetPKMData([In][Out] Pokemon pokemon, Save sav, int box, int slot)
        {
            //Pokemon pkm = new Pokemon();
            //int size = Marshal.SizeOf(typeof(Pokemon));
            //IntPtr pkmptr = Marshal.AllocHGlobal(size);
            //Marshal.StructureToPtr(pkm, pkmptr, false);
            SetPKMData_INTERNAL(pokemon, sav, box, slot);
            //pokemon = pkm;
            //Marshal.FreeHGlobal(pkmptr);
            //pkmptr = IntPtr.Zero;
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
            public int[] Stats
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

                }
            }
            public string GetBoxName(int box)
            {
                return PKMDS.GetBoxName(this, box);
            }
            public void WriteToFile(string FileName)
            {
                WriteSaveFile(this, FileName);
            }
        }
    }
}
