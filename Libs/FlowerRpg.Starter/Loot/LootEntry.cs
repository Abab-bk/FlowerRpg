using FlowerRpg.Inventories;
using FlowerRpg.Loot;

namespace FlowerRpg.Starter.Loot;

public readonly struct LootEntry(
    int itemId,
    int minQuantity = 1,
    int maxQuantity = 1,
    int weight = 1
) : ILootTableEntry
{
    public int ItemId { get; init; } = itemId;
    public int MinQuantity { get; init; } = minQuantity;
    public int MaxQuantity { get; init; } = maxQuantity;
    public int Weight { get; init; } = weight;

    public ItemStack ItemStack => new ItemStack(
        ItemId,
        Random.Shared.Next(MinQuantity, MaxQuantity + 1)
        );
}