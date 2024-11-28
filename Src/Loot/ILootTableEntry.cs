using FlowerRpg.Inventories;

namespace FlowerRpg.Loot;

public interface ILootTableEntry
{
    public ItemStack ItemStack { get; }
}