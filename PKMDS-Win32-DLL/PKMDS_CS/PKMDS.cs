using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
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
        public static extern int GetPKMMoveID(Pokemon pokemon, int moveid);

        [DllImport(PKMDS_WIN32_DLL, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.BStr)]
        public static extern string GetItemName(int itemid, int generation, int langid = LANG_ID);

        [DllImport(PKMDS_WIN32_DLL, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.BStr)]
        public static extern string GetMoveName(int moveid, int langid = LANG_ID);

        [DllImport(PKMDS_WIN32_DLL, CallingConvention = CallingConvention.Cdecl)]
        private static extern void GetPKMData_INTERNAL([In][Out] Pokemon pokemon, Save sav, int box, int slot);

        public static string[] GetPKMMoveNames(Pokemon pkm, int langid = LANG_ID)
        {
            string[] moves = { "", "", "", "" };
            for (int move = 0; move < 4; move++)
            {
                moves[move] = GetMoveName(GetPKMMoveID(pkm, move), langid);
            }
            return moves;
        }

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

    }

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    public class Pokemon
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 136)]
        public byte[] Data;
    }

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    public class Save
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 0x80000)]
        public byte[] Data;
    }
}
