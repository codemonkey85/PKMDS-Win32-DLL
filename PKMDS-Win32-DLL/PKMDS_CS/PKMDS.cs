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
#if DEBUG
        private const string folder = "..\\..\\..\\Debug\\";
#else
        private const string folder = "";
#endif
        [DllImport(folder + "PKMDS-Win32-DLL.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void OpenDB(string dbfilename);
        
        [DllImport(folder + "PKMDS-Win32-DLL.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void CloseDB();
        
        [DllImport(folder + "PKMDS-Win32-DLL.dll", CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.BStr)]
        public static extern string GetPKMName(int speciesid, int langid, string dbfilename);

        [DllImport(folder + "PKMDS-Win32-DLL.dll", CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.BStr)]
        public static extern string GetPKMName_FromSav(string savefile, int box, int slot, string dbfilename);

        [DllImport(folder + "PKMDS-Win32-DLL.dll", CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.BStr)]
        public static extern string GetTrainerName_FromSav(string savefile);

        [DllImport(folder + "PKMDS-Win32-DLL.dll", CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.BStr)]
        public static extern string GetBoxName(string savefile, int box);

        [DllImport(folder + "PKMDS-Win32-DLL.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int GetPKMStat(string savefile, int box, int slot, int stat, string dbfilename);

        [DllImport(folder + "PKMDS-Win32-DLL.dll", CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.BStr)]
        public static extern string GetItemName(int itemid, int generation, int langid, string dbfilename);

        [DllImport(folder + "PKMDS-Win32-DLL.dll", CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.BStr)]
        public static extern string GetMoveName(int moveid, int langid, string dbfilename);
    }
}
