namespace FlowerRpg.Items;

public interface IItemSlots
{
    public IEnumerable<int> AcceptSlots { get; set; }
    public IItem Item { get; }

    public bool CanPlaceItem(IHasItemSlots hasItemSlots);
    public bool TryPlaceItem(IHasItemSlots hasItemSlots);
    public void RemoveItem();
    
    public virtual bool HasItem() => Item != null;
}