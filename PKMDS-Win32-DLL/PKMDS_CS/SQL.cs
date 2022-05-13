using System.Runtime.InteropServices;
using static PKMDS_CS.PKMDS;

namespace PKMDS_CS
{
    public static class SQL
    {
        [DllImport(PKMDS_WIN32_DLL, CallingConvention = CallingConvention.Cdecl)]
        public static extern void OpenDB(string dbfilename);
        [DllImport(PKMDS_WIN32_DLL, CallingConvention = CallingConvention.Cdecl)]
        public static extern void CloseDB();
        [DllImport(PKMDS_WIN32_DLL, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        [return: MarshalAs(UnmanagedType.BStr)]
        public static extern string GetAString(string sql);
        [DllImport(PKMDS_WIN32_DLL, CallingConvention = CallingConvention.Cdecl)]
        public static extern int GetAnInt(string sql);
    }
}
