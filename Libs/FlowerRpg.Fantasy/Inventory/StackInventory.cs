using FlowerRpg.Fantasy.Items;
using FlowerRpg.Inventory;
using FlowerRpg.Items;

namespace FlowerRpg.Fantasy.Inventory;

// Maybe rework...
public class StackInventory(int slotCount) : IInventory<Item>
{
    public event Action<Item>
        OnItemAdded,
        OnItemRemoved;
    
    public IReadOnlyList<Item> Items => _items;
    private readonly List<Item> _items = new();
    
    public int SlotCount = slotCount;

    public int GetAllItemCount() => _items.Count;

    public bool HasItem(Item item)
    {
        foreach (var item1 in _items)
        {
            if (!item1.IsEqual(item)) continue;
            return true;
        }
        return false;
    }

    public bool AddItem(Item item)
    {
        if (SlotCount <= GetAllItemCount()) return false;
        
        var newItem = item.Clone();
        
        bool AddNewItem(Item addItem)
        {
            if (SlotCount <= GetAllItemCount()) return false;
            _items.Add(addItem);
            OnItemAdded?.Invoke(addItem);
            return true;
        }

        var needAdded = newItem.Quantity;
        
        while (needAdded > 0)
        {
            // if exists and has room to stack more.
            if (_items.Exists(x => x.IsEqual(newItem) && x.Quantity < newItem.MaxStack))
            {
                var item1 = _items.First(x => x.IsEqual(newItem) && x.Quantity < newItem.MaxStack);
                // calculate how many can be added
                var maxCanAdd = newItem.MaxStack - item1.Quantity;
                // add to stack
                var quantityAddToStack = Math.Min(needAdded, maxCanAdd);
                item1.Quantity += quantityAddToStack;
                needAdded -= quantityAddToStack;
            }
            else
            {
                return AddNewItem(newItem);
            }
        }

        return false;
    }

    public bool RemoveItem(Item item)
    {
        foreach (var item1 in _items)
        {
            if (!item1.IsEqual(item)) continue;
            _items.Remove(item1);
            OnItemRemoved?.Invoke(item);
            return true;
        }
        return false;
    }
}