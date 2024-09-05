using FlowerRpg.Inventory;

namespace FlowerRpg.Loot;

public interface ILootTableEntry
{
    public IItem Item { get; }
}