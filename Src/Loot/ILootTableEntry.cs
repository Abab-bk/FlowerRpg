using FlowerRpg.Items;

namespace FlowerRpg.Loot;

public interface ILootTableEntry
{
    public IItem Item { get; }
}