using FlowerRpg.Items;

namespace FlowerRpg.Loot;

public interface ILootTable<T> where T : ILootTableEntry
{
    public IItem GetLoot();
}