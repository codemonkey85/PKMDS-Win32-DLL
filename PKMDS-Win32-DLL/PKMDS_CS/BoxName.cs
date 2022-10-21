namespace PKMDS_CS;

[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode, Pack = 1)]
[Serializable]
public class BoxName
{
    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 20)]

    private string mName = string.Empty;
    [Browsable(true)]
    public string Name
    {
        get => mName;
        set => mName = value;
    }
}
