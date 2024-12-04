using FlowerRpg.Items;
using FlowerRpg.Items.Inventory;

namespace FlowerRpg.Starter.Items.Inventory;

public class StackInventory(int capacity = -1) : IInventory
{
    public int Capacity { get; } = capacity;
    
    private readonly List<IItemStack> _items = new();
    
    public bool AddItem(IItem item, int count = 1)
    {
        var itemStack = HasAvailableItemStack(item);

        if (itemStack == null)
        {
            if (!HasCapacity()) return false;
            _items.Add(new ItemStack(item, count));
            return true;
        }

        while (count != 0)
        {
            if (!itemStack.Add(1)) break;
            count--;
        }

        return true;
    }

    public bool RemoveItem(IItem item, int count = 1)
    {
        var itemStack = _items.FirstOrDefault(x => x.Item == item);

        if (itemStack == null) return false;

        while (count != 0)
        {
            if (!itemStack.Remove(1)) break;
            count--;
        }

        return true;
    }

    public IItem? PopItem(int itemId)
    {
        var stack = _items.FirstOrDefault(itemStack => itemStack.Item.Id == itemId);
        if (stack == null) return null;
        return stack.Pop();
    }

    public IEnumerable<IItemStack> GetItems() => _items;

    // public bool CanAdd(Item item)
    // {
    //     var stack = HasAvailableItemStack(item);
    //     
    //     if (stack == null)
    //     {
    //         if (GetUsedCapacity() >= Capacity) return false;
    //         return true;
    //     }
    //
    //     return true;
    // }

    private bool HasCapacity()
    {
        if (Capacity == -1) return true;
        return GetUsedCapacity() < Capacity;
    }

    private IItemStack? HasAvailableItemStack(IItem item) =>
        _items.FirstOrDefault(x => 
            x.Item == item && x.CanAdd(1)
        );

    public int GetUsedCapacity() => _items.Count;
}