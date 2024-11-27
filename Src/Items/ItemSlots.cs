namespace FlowerRpg.Items;

public class ItemSlots : IItemSlots
{
    public IEnumerable<int> AcceptSlots { get; set; }
    public IItem Item { get; private set; }
    
    public bool CanPlaceItem(IHasItemSlots hasItemSlots)
    {
        if (hasItemSlots is null) return false;
        return AcceptSlots.Any(hasItemSlots.Slots.Contains);
    }
    
    public bool TryPlaceItem(IHasItemSlots hasItemSlots)
    {
        if (hasItemSlots is null) return false;
        if (!CanPlaceItem(hasItemSlots)) return false;
        Item = hasItemSlots.Item;
        return true;
    }
    
    public void RemoveItem()
    {
        Item = null;
    }
}