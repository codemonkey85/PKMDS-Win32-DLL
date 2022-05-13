using System;
using System.Runtime.InteropServices;

namespace PKMDS_CS
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    [Serializable]
    internal class PCStorage_Private
    {
        public Box_Private Box(int box)
        {
            switch (box)
            {
                case 0:
                    return Box01;
                case 1:
                    return Box02;
                case 2:
                    return Box03;
                case 3:
                    return Box04;
                case 4:
                    return Box05;
                case 5:
                    return Box06;
                case 6:
                    return Box07;
                case 7:
                    return Box08;
                case 8:
                    return Box09;
                case 9:
                    return Box10;
                case 10:
                    return Box11;
                case 11:
                    return Box12;
                case 12:
                    return Box13;
                case 13:
                    return Box14;
                case 14:
                    return Box15;
                case 15:
                    return Box16;
                case 16:
                    return Box17;
                case 17:
                    return Box18;
                case 18:
                    return Box19;
                case 19:
                    return Box20;
                case 20:
                    return Box21;
                case 21:
                    return Box22;
                case 22:
                    return Box23;
                case 23:
                    return Box24;
                default:
                    return null;
            }
        }
        [NonSerialized()]
        private readonly Box_Private Box01 = new Box_Private();
        [NonSerialized()]
        private readonly Box_Private Box02 = new Box_Private();
        [NonSerialized()]
        private readonly Box_Private Box03 = new Box_Private();
        [NonSerialized()]
        private readonly Box_Private Box04 = new Box_Private();
        [NonSerialized()]
        private readonly Box_Private Box05 = new Box_Private();
        [NonSerialized()]
        private readonly Box_Private Box06 = new Box_Private();
        [NonSerialized()]
        private readonly Box_Private Box07 = new Box_Private();
        [NonSerialized()]
        private readonly Box_Private Box08 = new Box_Private();
        [NonSerialized()]
        private readonly Box_Private Box09 = new Box_Private();
        [NonSerialized()]
        private readonly Box_Private Box10 = new Box_Private();
        [NonSerialized()]
        private readonly Box_Private Box11 = new Box_Private();
        [NonSerialized()]
        private readonly Box_Private Box12 = new Box_Private();
        [NonSerialized()]
        private readonly Box_Private Box13 = new Box_Private();
        [NonSerialized()]
        private readonly Box_Private Box14 = new Box_Private();
        [NonSerialized()]
        private readonly Box_Private Box15 = new Box_Private();
        [NonSerialized()]
        private readonly Box_Private Box16 = new Box_Private();
        [NonSerialized()]
        private readonly Box_Private Box17 = new Box_Private();
        [NonSerialized()]
        private readonly Box_Private Box18 = new Box_Private();
        [NonSerialized()]
        private readonly Box_Private Box19 = new Box_Private();
        [NonSerialized()]
        private readonly Box_Private Box20 = new Box_Private();
        [NonSerialized()]
        private readonly Box_Private Box21 = new Box_Private();
        [NonSerialized()]
        private readonly Box_Private Box22 = new Box_Private();
        [NonSerialized()]
        private readonly Box_Private Box23 = new Box_Private();
        [NonSerialized()]
        private readonly Box_Private Box24 = new Box_Private();
        public PCStorage_Private()
        {

        }
    }
}
