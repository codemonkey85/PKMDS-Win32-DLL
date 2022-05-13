using System.Drawing;
using static PKMDS_CS.PKMDS;

namespace PKMDS_CS
{
    public class Move
    {
        private ushort moveid;
        public Move(ushort moveid) => this.moveid = moveid;
        public Move() => moveid = 0;
        public ushort MoveID
        {
            get => moveid;
            set => moveid = value;
        }
        public string MoveName
        {
            get
            {
                string ret = GetMoveName(MoveID);
                return ret ?? string.Empty;
            }
        }
        public string MoveFlavor
        {
            get
            {
                string ret = GetMoveFlavor(MoveID);
                return ret ?? string.Empty;
            }
        }
        public Image MoveTypeImage => GetResourceByName(GetMoveTypeName(MoveID).ToLower());
        public Image MoveCategoryImage => GetMoveCategoryImage(MoveID);
        public int MovePower => GetMovePower(MoveID);
        public decimal MoveAccuracy => GetMoveAccuracy(MoveID);
        public int MoveBasePP => GetMoveBasePP(MoveID);
    }
}
