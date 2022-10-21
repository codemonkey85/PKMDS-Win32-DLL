namespace PKMDS_CS;

[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode, Pack = 1)]
[Serializable]
internal class BoxWallpapers_Private
{
    public BoxWallpaper? Wallpapers(int slot) => slot switch
    {
        00 => BoxName01,
        01 => BoxName02,
        02 => BoxName03,
        03 => BoxName04,
        04 => BoxName05,
        05 => BoxName06,
        06 => BoxName07,
        07 => BoxName08,
        08 => BoxName09,
        09 => BoxName10,
        10 => BoxName11,
        11 => BoxName12,
        12 => BoxName13,
        13 => BoxName14,
        14 => BoxName15,
        15 => BoxName16,
        16 => BoxName17,
        17 => BoxName18,
        18 => BoxName19,
        19 => BoxName20,
        20 => BoxName21,
        21 => BoxName22,
        22 => BoxName23,
        23 => BoxName24,
        _ => null,
    };
    public BoxWallpaper BoxName01 = new();
    public BoxWallpaper BoxName02 = new();
    public BoxWallpaper BoxName03 = new();
    public BoxWallpaper BoxName04 = new();
    public BoxWallpaper BoxName05 = new();
    public BoxWallpaper BoxName06 = new();
    public BoxWallpaper BoxName07 = new();
    public BoxWallpaper BoxName08 = new();
    public BoxWallpaper BoxName09 = new();
    public BoxWallpaper BoxName10 = new();
    public BoxWallpaper BoxName11 = new();
    public BoxWallpaper BoxName12 = new();
    public BoxWallpaper BoxName13 = new();
    public BoxWallpaper BoxName14 = new();
    public BoxWallpaper BoxName15 = new();
    public BoxWallpaper BoxName16 = new();
    public BoxWallpaper BoxName17 = new();
    public BoxWallpaper BoxName18 = new();
    public BoxWallpaper BoxName19 = new();
    public BoxWallpaper BoxName20 = new();
    public BoxWallpaper BoxName21 = new();
    public BoxWallpaper BoxName22 = new();
    public BoxWallpaper BoxName23 = new();
    public BoxWallpaper BoxName24 = new();
}
