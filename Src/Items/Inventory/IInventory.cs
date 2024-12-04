namespace FlowerRpg.Items.Inventory;

public interface IInventory
{
    public bool AddItem(IItem item, int count = 1);
    public bool RemoveItem(IItem item, int count = 1);
    
    public IItem PopItem(int itemId);
    public IEnumerable<IItemStack> GetItems();
}