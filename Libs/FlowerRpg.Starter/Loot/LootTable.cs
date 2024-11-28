using FlowerRpg.Items;
using FlowerRpg.Loot;
using FlowerRpg.Starter.Extensions;
using KaimiraGames;

namespace FlowerRpg.Starter.Loot;

public class LootTable : ILootTable<LootEntry>
{
    public WeightedList<LootEntry> AvailableLoot { get; }

    public IItem GetLoot() => AvailableLoot.Next().GetItem();

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