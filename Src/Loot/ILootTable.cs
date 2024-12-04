using FlowerRpg.Items;

namespace FlowerRpg.Loot;

public interface ILootTable
{
    public IEnumerable<IItemStack> GetLoots();
}