namespace FlowerRpg.Inventory;

public interface IInventory
{
    public IReadOnlyList<IItem> Items { get; }
    public void AddItem(IItem item);
    public void RemoveItem(IItem item);
}