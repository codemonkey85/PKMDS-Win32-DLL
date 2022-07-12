namespace PKMDS_CS;

public class Ball
{
    public Ball(byte ballid) => BallID = ballid;
    public Ball() => BallID = 0;
    public byte BallID { get; set; }
    public string BallName => BallID switch
    {
        0 => "Poké Ball",
        1 => "Master Ball",
        2 => "Ultra Ball",
        3 => "Great Ball",
        4 => "Poké Ball",
        5 => "Safari Ball",
        6 => "Net Ball",
        7 => "Dive Ball",
        8 => "Nest Ball",
        9 => "Repeat Ball",
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
