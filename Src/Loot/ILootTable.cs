using FlowerRpg.Items;

namespace FlowerRpg.Loot;

public interface ILootTable<T> where T : ILootTableEntry
{
    public ICollection<T> AvailableLoot { get; }
    public IItem GetLoot();
}