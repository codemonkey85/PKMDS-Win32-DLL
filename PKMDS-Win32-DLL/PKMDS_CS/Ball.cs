using System.Drawing;
using static PKMDS_CS.PKMDS;

namespace PKMDS_CS
{
    public class Ball
    {
        private byte ballid;
        public Ball(byte ballid) => this.ballid = ballid;
        public Ball() => ballid = 0;
        public byte BallID
        {
            get => ballid;
            set => ballid = value;
        }
        public string BallName
        {
            get
            {
                switch (BallID)
                {
                    case 0:
                        return "Poké Ball";
                    case 1:
                        return "Master Ball";
                    case 2:
                        return "Ultra Ball";
                    case 3:
                        return "Great Ball";
                    case 4:
                        return "Poké Ball";
                    case 5:
                        return "Safari Ball";
                    case 6:
                        return "Net Ball";
                    case 7:
                        return "Dive Ball";
                    case 8:
                        return "Nest Ball";
                    case 9:
                        return "Repeat Ball";
                    case 10:
                        return "Timer Ball";
                    case 11:
                        return "Luxury Ball";
                    case 12:
                        return "Premier Ball";
                    case 13:
                        return "Dusk Ball";
                    case 14:
                        return "Heal Ball";
                    case 15:
                        return "Quick Ball";
                    case 16:
                        return "Cherish Ball";
                    case 17:
                        return "Fast Ball";
                    case 18:
                        return "Level Ball";
                    case 19:
                        return "Lure Ball";
                    case 20:
                        return "Heavy Ball";
                    case 21:
                        return "Love Ball";
                    case 22:
                        return "Friend Ball";
                    case 23:
                        return "Moon Ball";
                    case 24:
                        return "Sport Ball";
                    default:
                        return "Dream Ball";
                }
            }
        }
        public Image BallImage => GetBallImage(ballid);
    }
}
