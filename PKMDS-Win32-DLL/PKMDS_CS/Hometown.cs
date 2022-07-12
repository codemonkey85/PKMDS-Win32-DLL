namespace PKMDS_CS;

public class Hometown
{
    public Hometown(byte hometownid) => HometownID = hometownid;
    public Hometown() => HometownID = 0;
    public byte HometownID { get; set; }
    public string HometownName => HometownID switch
    {
        0 => "Colosseum Bonus",
        1 => "Sapphire",
        2 => "Ruby",
        3 => "Emerald",
        4 => "FireRed",
        5 => "LeafGreen",
        7 => "HeartGold",
        8 => "SoulSilver",
        10 => "Diamond",
        11 => "Pearl",
        12 => "Platinum",
        15 => "Colosseum / XD",
        20 => "White",
        21 => "Black",
        22 => "White 2",
        23 => "Black 2",
        _ => string.Empty,
    };
}
