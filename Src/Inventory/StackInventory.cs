namespace FlowerRpg.Inventory;

public class StackInventory : IInventory
{
    public IReadOnlyList<IItem> Items => _items;
    
    private List<IItem> _items = new();
    
    public void AddItem(IItem item)
    {
    }

    public void RemoveItem(IItem item)
    {
        throw new NotImplementedException();
    }
}