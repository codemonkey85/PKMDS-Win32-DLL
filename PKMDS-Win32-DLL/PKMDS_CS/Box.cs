namespace PKMDS_CS;

public class Box : ObservableCollection<Pokemon>
{
    public Box()
    {

    }
    [Browsable(true)]
    [DataMember(Name = "Grid")]
    public Image Grid => GetBoxGrid(this);
}
