namespace PKMDS_CS;

public class Item
{
    public Item() => ItemID = 0;
    public Item(ushort itemid) => ItemID = itemid;

    public ushort ItemID { get; set; }
    public string ItemName => GetItemName(ItemID) ?? string.Empty;
    public string ItemFlavor
    {
        get
        {
            var flavor = GetItemFlavor(ItemID);
            return flavor == null ? string.Empty : flavor.Replace("\n", " ");
        }
    }
    public Image ItemImage => ItemID == 0 ? null : GetItemImage(ItemID);
}
