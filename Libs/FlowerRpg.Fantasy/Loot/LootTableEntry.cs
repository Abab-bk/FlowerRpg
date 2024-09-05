using FlowerRpg.Items;
using FlowerRpg.Loot;
using FlowerRpg.Requirements;

namespace FlowerRpg.Fantasy.Loot;

public struct LootTableEntry() : ILootTableEntry
{
    public IEnumerable<Requirement> Requirements { get; set; } = [];
    public IItem Item { get; set; }
    public float Weight { get; set; }
}