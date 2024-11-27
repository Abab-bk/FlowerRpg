using FlowerRpg.Items;

namespace FlowerRpg.Inventories;

public interface IInventory<in T> where T : IItem
{
    public IReadOnlyList<ItemStack> Items { get; }
    
    public bool AddItem(T item, int count = 1);
    public bool AddItem(T item, int count, int addedCount);
    public bool AddItem(ItemStack item);
    
    public bool RemoveItem(T item, int count = 1);
    public bool RemoveItem(T item, int count, int removedCount);
    public bool RemoveItem(ItemStack item);
    
    public bool HasItem(T item);
    public bool HasItem(ItemStack item);

    public bool TryGetItemStack(T item, out ItemStack itemStack);
    public bool TryGetItemStack(int id, out ItemStack itemStack);
    
    public int GetAllItemCount();
}