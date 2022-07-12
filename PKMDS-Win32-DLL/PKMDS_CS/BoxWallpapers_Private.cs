namespace PKMDS_CS;

[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode, Pack = 1)]
[Serializable]
internal class BoxWallpapers_Private
{
    public BoxWallpaper Wallpapers(int slot) => slot switch
    {
        0 => BoxName01,
        1 => BoxName02,
        2 => BoxName03,
        3 => BoxName04,
        4 => BoxName05,
        5 => BoxName06,
        6 => BoxName07,
        7 => BoxName08,
        8 => BoxName09,
        9 => BoxName10,
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
    public BoxWallpaper BoxName01;
    public BoxWallpaper BoxName02;
    public BoxWallpaper BoxName03;
    public BoxWallpaper BoxName04;
    public BoxWallpaper BoxName05;
    public BoxWallpaper BoxName06;
    public BoxWallpaper BoxName07;
    public BoxWallpaper BoxName08;
    public BoxWallpaper BoxName09;
    public BoxWallpaper BoxName10;
    public BoxWallpaper BoxName11;
    public BoxWallpaper BoxName12;
    public BoxWallpaper BoxName13;
    public BoxWallpaper BoxName14;
    public BoxWallpaper BoxName15;
    public BoxWallpaper BoxName16;
    public BoxWallpaper BoxName17;
    public BoxWallpaper BoxName18;
    public BoxWallpaper BoxName19;
    public BoxWallpaper BoxName20;
    public BoxWallpaper BoxName21;
    public BoxWallpaper BoxName22;
    public BoxWallpaper BoxName23;
    public BoxWallpaper BoxName24;
}
