using System;
using System.Drawing;
using System.Runtime.InteropServices;

namespace PKMDS_CS
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode, Pack = 1)]
    [Serializable]
    public class BoxWallpaper
    {
        private byte mWallpaper;
        public byte WallpaperIndex
        {
            get => mWallpaper;
            set => mWallpaper = value;
        }
        public Image Wallpaper => GetWallpaperImage(WallpaperIndex);
    }
}
