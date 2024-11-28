using FlowerRpg.Items;
using FlowerRpg.Starter.Items;
using FlowerRpg.Starter.Loot;

namespace FlowerRpg.Starter.Extensions;

public static class LootEntryExtension
{
    public static IItem GetItem(this LootEntry lootEntry)
    {
        return new Item()
        {
            Id = lootEntry.ItemId
        };
    }
}