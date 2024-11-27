using FlowerRpg.Inventories;
using FlowerRpg.Starter.Items;

namespace FlowerRpg.Starter.Inventories;

public class StackInventory : IInventory<Item>
{
    public event Action<ItemStack> OnItemAdded = delegate { };
    public event Action<ItemStack> OnItemRemoved = delegate { };
    public event Action<ItemStack> OnItemStackRemoved = delegate { };
    
    public IReadOnlyList<ItemStack> Items => _items;
    private readonly List<ItemStack> _items = new();

    private bool InnerAddItem(int itemId, int count, out int addedCount)
    {
        if (TryGetItemStack(itemId, out var itemStack))
        {
            itemStack.Count += count;
            addedCount = count;
            
            OnItemAdded(itemStack);
            
            return true;
        }

        _items.Add(new ItemStack(itemId, count));
        addedCount = count;
        return true;
    }

    public bool AddItem(Item item, int count = 1) =>
        InnerAddItem(item.Id, count, out var _);

    public bool AddItem(Item item, int count, int addedCount) =>
        InnerAddItem(item.Id, count, out addedCount);

    public bool AddItem(ItemStack item) =>
        InnerAddItem(item.ItemId, item.Count, out var _);

    private bool InnerRemoveItem(Item item, int count, out int removedCount)
    {
        if (TryGetItemStack(item, out var itemStack))
        {
            var amountToRemove = count;
            removedCount = 0;
            while (amountToRemove > 0)
            {
                itemStack.Count -= 1;
                amountToRemove -= 1;
                removedCount += 1;
                
                if (itemStack.Count <= 0)
                {
                    _items.Remove(itemStack);
                    OnItemStackRemoved(itemStack);
                    return true;
                }
            }
            OnItemRemoved(itemStack);
            return true;
        }

        removedCount = 0;
        return false;
    }

    public bool RemoveItem(Item item, int count = 1) =>
        InnerRemoveItem(item, count, out var _);

    public bool RemoveItem(Item item, int count, int removedCount) =>
        InnerRemoveItem(item, count, out removedCount);

    public bool RemoveItem(ItemStack item)
    {
        if (TryGetItemStack(item.ItemId, out var itemStack))
        {
            _items.Remove(itemStack);
            OnItemStackRemoved(itemStack);
            return true;
        }

        return false;
    }

    public bool HasItem(Item item) => TryGetItemStack(item, out _);
    public bool HasItem(ItemStack item) => _items.Contains(item);

    public bool TryGetItemStack(Item item, out ItemStack itemStack)
    {
        if (TryGetItemStack(item.Id, out itemStack)) return true;
        itemStack = default;
        return false;
    }

    public bool TryGetItemStack(int id, out ItemStack itemStack)
    {
        itemStack = Items.First(i => i.ItemId == id);
        if (itemStack != default) return true;
        return false;
    }

    public int GetAllItemCount() => Items.Sum(i => i.Count);
}