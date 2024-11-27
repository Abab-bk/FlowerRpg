namespace FlowerRpg.Inventories;

public struct ItemStack(
    int itemId,
    int count
    ) : IEquatable<ItemStack>
{
    public int ItemId => itemId;
    public int Count { get; set; } = count;
    
    public bool Equals(ItemStack other) => Count == other.Count && ItemId == other.ItemId;

    public override bool Equals(object obj)
    {
        if (obj is null) return false;
        return obj is ItemStack other && Equals(other);
    }

    public override int GetHashCode() => (ItemId * 397) ^ Count;
    
    public static bool operator ==(ItemStack left, ItemStack right) => left.Equals(right);
    public static bool operator !=(ItemStack left, ItemStack right) => !(left == right);
}