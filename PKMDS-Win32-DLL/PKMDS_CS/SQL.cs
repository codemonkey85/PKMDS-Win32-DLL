namespace PKMDS_CS;

public static partial class SQL
{
    private const string PKMDS_WIN32_DLL = "PKMDS-Win32-DLL.dll";

    [LibraryImport(PKMDS_WIN32_DLL, StringMarshalling = StringMarshalling.Utf16)]
    [UnmanagedCallConv(CallConvs = new Type[] { typeof(CallConvCdecl) })]
    public static partial void OpenDB(string dbfilename);

    [LibraryImport(PKMDS_WIN32_DLL)]
    [UnmanagedCallConv(CallConvs = new Type[] { typeof(CallConvCdecl) })]
#pragma warning disable CA1401 // P/Invokes should not be visible
    public static partial void CloseDB();
#pragma warning restore CA1401 // P/Invokes should not be visible

    [LibraryImport(PKMDS_WIN32_DLL, StringMarshalling = StringMarshalling.Utf16)]
    [UnmanagedCallConv(CallConvs = new Type[] { typeof(CallConvCdecl) })]
    [return: MarshalAs(UnmanagedType.BStr)]
    internal static partial string GetAString(string sql);

    [LibraryImport(PKMDS_WIN32_DLL, StringMarshalling = StringMarshalling.Utf16)]
    [UnmanagedCallConv(CallConvs = new Type[] { typeof(CallConvCdecl) })]
    internal static partial int GetAnInt(string sql);
}
