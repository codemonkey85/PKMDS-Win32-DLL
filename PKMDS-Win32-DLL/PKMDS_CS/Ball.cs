namespace PKMDS_CS;

public class Ball
{
    public Ball(byte ballid) => BallID = ballid;
    public Ball() => BallID = 0;
    public byte BallID { get; set; }
    public string BallName => BallID switch
    {
        00 => "Poké Ball",
        01 => "Master Ball",
        02 => "Ultra Ball",
        03 => "Great Ball",
        04 => "Poké Ball",
        05 => "Safari Ball",
        06 => "Net Ball",
        07 => "Dive Ball",
        08 => "Nest Ball",
        09 => "Repeat Ball",
        10 => "Timer Ball",
        11 => "Luxury Ball",
        12 => "Premier Ball",
        13 => "Dusk Ball",
        14 => "Heal Ball",
        15 => "Quick Ball",
        16 => "Cherish Ball",
        17 => "Fast Ball",
        18 => "Level Ball",
        19 => "Lure Ball",
        20 => "Heavy Ball",
        21 => "Love Ball",
        22 => "Friend Ball",
        23 => "Moon Ball",
        24 => "Sport Ball",
        _ => "Dream Ball",
    };
    public Image BallImage => GetBallImage(BallID);
}
