using System.Drawing;
using static PKMDS_CS.PKMDS;

namespace PKMDS_CS
{
    public class Item
    {
        public Item() => itemid = 0;
        public Item(ushort itemid) => this.itemid = itemid;
        private ushort itemid;
        public ushort ItemID
        {
            get => itemid;
            set => itemid = value;
        }
        public string ItemName => GetItemName(itemid) ?? string.Empty;
        public string ItemFlavor
        {
            get
            {
                string flavor = GetItemFlavor(itemid);
                return flavor == null ? string.Empty : flavor.Replace("\n", " ");
            }
        }
        public Image ItemImage => itemid == 0 ? null : GetItemImage(itemid);
    }
}
