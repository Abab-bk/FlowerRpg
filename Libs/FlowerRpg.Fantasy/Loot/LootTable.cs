using FlowerRpg.Inventory;
using FlowerRpg.Loot;

namespace FlowerRpg.Fantasy.Loot;

public class LootTable : ILootTable<LootTableEntry>
{
    public ICollection<LootTableEntry> AvailableLoot { get; set; } = new List<LootTableEntry>();
    
    public LootTable(){}
    
    public LootTable(ICollection<LootTableEntry> availableLoot)
    {
        AvailableLoot = availableLoot;
    }

    public IItem GetLoot()
    {
        if (AvailableLoot.Count == 0) return null;
        
        var totalWeight = AvailableLoot.Sum(x => x.Weight);
        var randomValue = Random.Shared.NextDouble() * totalWeight;

        List<IItem> items = new List<IItem>();

        var currentWeight = 0f;
        foreach (var entry in AvailableLoot)
        {
            currentWeight += entry.Weight;
            if (currentWeight > randomValue)
            {
                items.Add(entry.Item);
            }
        }
        
        if (items.Count == 0) return null;
        return items[Random.Shared.Next(items.Count)];
    }
}