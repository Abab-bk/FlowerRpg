namespace FlowerRpg.Items;

public interface IItemStack
{
    public IItem Item { get; }
    public int Count { get; }
    
    public bool CanAdd(int count);
    public bool Add(int count);
    public bool Remove(int count);
    public IItem Pop();
}