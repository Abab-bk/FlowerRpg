namespace FlowerRpg.Inventory;

public interface IInventory<T> where T : IItem
{
    public IReadOnlyList<T> Items { get; }
    public bool AddItem(T item);
    public bool RemoveItem(T item);
    public bool HasItem(T item);
    public int GetAllItemCount();
}