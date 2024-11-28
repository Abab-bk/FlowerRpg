using FlowerRpg.Inventories;

namespace FlowerRpg.Loot;

public interface ILootTable<T> where T : ILootTableEntry
{
    public IEnumerable<ItemStack> GetLoots(int count = 1);
    public ItemStack GetLoot();
}