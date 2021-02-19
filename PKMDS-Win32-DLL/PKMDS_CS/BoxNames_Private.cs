using System;
using System.Runtime.InteropServices;

namespace PKMDS_CS
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode, Pack = 1)]
    [Serializable]
    internal class BoxNames_Private
    {
        public BoxName Boxes(int slot)
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
        public BoxName BoxName01;
        public BoxName BoxName02;
        public BoxName BoxName03;
        public BoxName BoxName04;
        public BoxName BoxName05;
        public BoxName BoxName06;
        public BoxName BoxName07;
        public BoxName BoxName08;
        public BoxName BoxName09;
        public BoxName BoxName10;
        public BoxName BoxName11;
        public BoxName BoxName12;
        public BoxName BoxName13;
        public BoxName BoxName14;
        public BoxName BoxName15;
        public BoxName BoxName16;
        public BoxName BoxName17;
        public BoxName BoxName18;
        public BoxName BoxName19;
        public BoxName BoxName20;
        public BoxName BoxName21;
        public BoxName BoxName22;
        public BoxName BoxName23;
        public BoxName BoxName24;
    }
}
