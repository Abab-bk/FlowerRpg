using FlowerRpg.Items;

namespace FlowerRpg.Starter.Items;

public class Item : IItem
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Desc { get; set; } = string.Empty;
    public int MaxStack { get; set; } = 1;
    
    public bool IsUnique { get; set; } = false;
    
    public IItem Clone()
    {
        return new Item
        {
            Id = Id,
            Name = Name,
            Desc = Desc,
            MaxStack = MaxStack
        };
    }

    public bool Equals(IItem other)
    {
        if (IsUnique) return false;
        return Id == other.Id &&
               Name == other.Name &&
               Desc == other.Desc &&
               MaxStack == other.MaxStack;
    }
}