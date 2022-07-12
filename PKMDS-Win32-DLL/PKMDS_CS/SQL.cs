namespace PKMDS_CS;

public static class SQL
{
    private const string PKMDS_WIN32_DLL = "PKMDS-Win32-DLL.dll";
    
    [DllImport(PKMDS_WIN32_DLL, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode)]
    public static extern void OpenDB(string dbfilename);

    [DllImport(PKMDS_WIN32_DLL, CallingConvention = CallingConvention.Cdecl)]
    public static extern void CloseDB();

    [DllImport(PKMDS_WIN32_DLL, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode)]
    [return: MarshalAs(UnmanagedType.BStr)]
    internal static extern string GetAString(string sql);

    [DllImport(PKMDS_WIN32_DLL, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode)]
    internal static extern int GetAnInt(string sql);
}
