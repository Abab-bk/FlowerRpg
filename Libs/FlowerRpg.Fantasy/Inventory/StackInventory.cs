using FlowerRpg.Inventory;

namespace FlowerRpg.Fantasy.Inventory;

public class StackInventory(int slotCount) : IInventory<Item>
{
    public event Action<Item>
        OnItemAdded,
        OnItemRemoved;
    
    public IReadOnlyList<Item> Items => _items;
    private List<Item> _items = new();
    
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
        bool AddNewItem(Item addItem)
        {
            if (_items.Count >= SlotCount) return false;
            _items.Add(addItem);
            OnItemAdded?.Invoke(addItem);
            return true;
        }
        
        // if exists in inventory
        foreach (var item1 in _items)
        {
            if (!item1.IsEqual(item)) continue;
            if (item1.TryAddQuantity(item.Quantity, out var needAdded))
            {
                return true;
            }

            // if exists and to max, add new one
            var newItem = item1.Clone();
            item1.Quantity = needAdded;
            return AddNewItem(newItem);
        }

        return AddNewItem(item.Clone());
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