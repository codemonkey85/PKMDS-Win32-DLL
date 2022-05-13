using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.Serialization;
using static PKMDS_CS.PKMDS;

namespace PKMDS_CS
{
    public class Box : ObservableCollection<Pokemon>
    {
        public Box()
        {

        }
        [Browsable(true)]
        [DataMember(Name = "Grid")]
        public Image Grid => GetBoxGrid(this);
    }
}
