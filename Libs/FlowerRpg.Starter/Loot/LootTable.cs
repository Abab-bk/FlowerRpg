using FlowerRpg.Inventories;
using FlowerRpg.Loot;
using KaimiraGames;

namespace FlowerRpg.Starter.Loot;

public class LootTable : ILootTable<LootEntry>
{
    public WeightedList<LootEntry> AvailableLoot { get; }
    
    public IEnumerable<ItemStack> GetLoots(int count = 1)
    {
        var loots = new List<ItemStack>();
        for (var i = 0; i < count; i++)
        {
            loots.Add(AvailableLoot.Next().ItemStack);
        }
        return loots.ToArray();
    }

    public ItemStack GetLoot() => AvailableLoot.Next().ItemStack;

    public LootTable(IEnumerable<LootEntry> lootEntries)
    {
        var items = new List<WeightedListItem<LootEntry>>();
        
        foreach (var lootEntry in lootEntries)
        {
            items.Add(new WeightedListItem<LootEntry>(lootEntry, lootEntry.Weight));
        }
        
        AvailableLoot = new WeightedList<LootEntry>(items);
    }
}