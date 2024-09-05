namespace FlowerRpg.Loot;

public interface IIsLootTable<out T> where T : ILootTable<ILootTableEntry>
{
    public T LootTable { get; }
}