using System.Drawing;
using static PKMDS_CS.PKMDS;

namespace PKMDS_CS
{
    public class Move
    {
        public Move(ushort moveid) => MoveID = moveid;
        public Move() => MoveID = 0;
        public ushort MoveID { get; set; }
        public string MoveName
        {
            get
            {
                var ret = GetMoveName(MoveID);
                return ret ?? string.Empty;
            }
        }
        public string MoveFlavor
        {
            get
            {
                var ret = GetMoveFlavor(MoveID);
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
