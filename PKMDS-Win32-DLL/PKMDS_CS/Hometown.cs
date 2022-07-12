namespace PKMDS_CS;

public class Hometown
{
    public Hometown(byte hometownid) => HometownID = hometownid;
    public Hometown() => HometownID = 0;
    public byte HometownID { get; set; }
    public string HometownName => HometownID switch
    {
        00 => "Colosseum Bonus",
        01 => "Sapphire",
        02 => "Ruby",
        03 => "Emerald",
        04 => "FireRed",
        05 => "LeafGreen",
        07 => "HeartGold",
        08 => "SoulSilver",
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
