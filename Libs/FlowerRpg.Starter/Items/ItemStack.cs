using FlowerRpg.Items;

namespace FlowerRpg.Starter.Items;

public class ItemStack(IItem item, int count = 1) : IItemStack
{
    public IItem Item { get; } = item;
    public int Count { get; private set; } = count;

    public bool CanAdd(int count)
    {
        if (count <= 0) return false;
        if (Count >= Item.MaxStack) return false;
        return true;
    }

    public bool Add(int count)
    {
        if (count <= 0) return false;
        if (Count >= Item.MaxStack) return false;
        
        Count += count;
        return true;
    }

    public bool Remove(int count)
    {
        if (count <= 0) return false;
        Count = Math.Max(0, Count - count);
        return true;
    }

    public IItem Pop()
    {
        return Item.Clone();
    }
}