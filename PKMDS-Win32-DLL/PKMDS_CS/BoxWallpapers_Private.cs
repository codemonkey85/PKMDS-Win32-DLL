using System;
using System.Runtime.InteropServices;

namespace PKMDS_CS
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode, Pack = 1)]
    [Serializable]
    internal class BoxWallpapers_Private
    {
        public BoxWallpaper Wallpapers(int slot)
        {
            switch (slot)
            {
                case 0:
                    return BoxName01;
                case 1:
                    return BoxName02;
                case 2:
                    return BoxName03;
                case 3:
                    return BoxName04;
                case 4:
                    return BoxName05;
                case 5:
                    return BoxName06;
                case 6:
                    return BoxName07;
                case 7:
                    return BoxName08;
                case 8:
                    return BoxName09;
                case 9:
                    return BoxName10;
                case 10:
                    return BoxName11;
                case 11:
                    return BoxName12;
                case 12:
                    return BoxName13;
                case 13:
                    return BoxName14;
                case 14:
                    return BoxName15;
                case 15:
                    return BoxName16;
                case 16:
                    return BoxName17;
                case 17:
                    return BoxName18;
                case 18:
                    return BoxName19;
                case 19:
                    return BoxName20;
                case 20:
                    return BoxName21;
                case 21:
                    return BoxName22;
                case 22:
                    return BoxName23;
                case 23:
                    return BoxName24;
                default:
                    return null;
            }
        }
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
}
