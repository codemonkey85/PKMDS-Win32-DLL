using System;
using System.Runtime.InteropServices;

namespace PKMDS_CS
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    [Serializable]
    internal class Box_Private
    {
        public Pokemon Pokemon(int slot)
        {
            switch (slot)
            {
                case 0:
                    return Pokemon01;
                case 1:
                    return Pokemon02;
                case 2:
                    return Pokemon03;
                case 3:
                    return Pokemon04;
                case 4:
                    return Pokemon05;
                case 5:
                    return Pokemon06;
                case 6:
                    return Pokemon07;
                case 7:
                    return Pokemon08;
                case 8:
                    return Pokemon09;
                case 9:
                    return Pokemon10;
                case 10:
                    return Pokemon11;
                case 11:
                    return Pokemon12;
                case 12:
                    return Pokemon13;
                case 13:
                    return Pokemon14;
                case 14:
                    return Pokemon15;
                case 15:
                    return Pokemon16;
                case 16:
                    return Pokemon17;
                case 17:
                    return Pokemon18;
                case 18:
                    return Pokemon19;
                case 19:
                    return Pokemon20;
                case 20:
                    return Pokemon21;
                case 21:
                    return Pokemon22;
                case 22:
                    return Pokemon23;
                case 23:
                    return Pokemon24;
                case 24:
                    return Pokemon25;
                case 25:
                    return Pokemon26;
                case 26:
                    return Pokemon27;
                case 27:
                    return Pokemon28;
                case 28:
                    return Pokemon29;
                case 29:
                    return Pokemon30;
                default:
                    return null;
            }
        }
        [NonSerialized()]
        private readonly Pokemon Pokemon01 = new Pokemon();
        [NonSerialized()]
        private readonly Pokemon Pokemon02 = new Pokemon();
        [NonSerialized()]
        private readonly Pokemon Pokemon03 = new Pokemon();
        [NonSerialized()]
        private readonly Pokemon Pokemon04 = new Pokemon();
        [NonSerialized()]
        private readonly Pokemon Pokemon05 = new Pokemon();
        [NonSerialized()]
        private readonly Pokemon Pokemon06 = new Pokemon();
        [NonSerialized()]
        private readonly Pokemon Pokemon07 = new Pokemon();
        [NonSerialized()]
        private readonly Pokemon Pokemon08 = new Pokemon();
        [NonSerialized()]
        private readonly Pokemon Pokemon09 = new Pokemon();
        [NonSerialized()]
        private readonly Pokemon Pokemon10 = new Pokemon();
        [NonSerialized()]
        private readonly Pokemon Pokemon11 = new Pokemon();
        [NonSerialized()]
        private readonly Pokemon Pokemon12 = new Pokemon();
        [NonSerialized()]
        private readonly Pokemon Pokemon13 = new Pokemon();
        [NonSerialized()]
        private readonly Pokemon Pokemon14 = new Pokemon();
        [NonSerialized()]
        private readonly Pokemon Pokemon15 = new Pokemon();
        [NonSerialized()]
        private readonly Pokemon Pokemon16 = new Pokemon();
        [NonSerialized()]
        private readonly Pokemon Pokemon17 = new Pokemon();
        [NonSerialized()]
        private readonly Pokemon Pokemon18 = new Pokemon();
        [NonSerialized()]
        private readonly Pokemon Pokemon19 = new Pokemon();
        [NonSerialized()]
        private readonly Pokemon Pokemon20 = new Pokemon();
        [NonSerialized()]
        private readonly Pokemon Pokemon21 = new Pokemon();
        [NonSerialized()]
        private readonly Pokemon Pokemon22 = new Pokemon();
        [NonSerialized()]
        private readonly Pokemon Pokemon23 = new Pokemon();
        [NonSerialized()]
        private readonly Pokemon Pokemon24 = new Pokemon();
        [NonSerialized()]
        private readonly Pokemon Pokemon25 = new Pokemon();
        [NonSerialized()]
        private readonly Pokemon Pokemon26 = new Pokemon();
        [NonSerialized()]
        private readonly Pokemon Pokemon27 = new Pokemon();
        [NonSerialized()]
        private readonly Pokemon Pokemon28 = new Pokemon();
        [NonSerialized()]
        private readonly Pokemon Pokemon29 = new Pokemon();
        [NonSerialized()]
        private readonly Pokemon Pokemon30 = new Pokemon();
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 0x10)]
        private readonly byte[] Data;
        public Box_Private()
        {

        }
    }
}
