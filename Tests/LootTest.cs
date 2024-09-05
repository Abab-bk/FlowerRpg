using FlowerRpg.Fantasy.Inventory;
using FlowerRpg.Fantasy.Loot;

namespace Tests;

public class LootTest
{
    private LootTable _lootTable;
    
    [SetUp]
    public void Setup()
    {
        _lootTable = new LootTable();
    }

    [Test]
    public void GerLoot_Return_True()
    {
        _lootTable.AvailableLoot = new List<LootTableEntry>()
        {
            new LootTableEntry()
            {
                Item = new Item(new ItemTemplate(){}),
                Weight = 0.5f
            },
            new LootTableEntry()
            {
                Item = new Item(new ItemTemplate(){}),
                Weight = 0.5f
            }
        };

        var loot = _lootTable.GetLoot();
        Assert.IsTrue(loot != null);
    }
    
    [Test]
    public void GerLoot_Return_False()
    {
        _lootTable.AvailableLoot = new List<LootTableEntry>()
        {
            new LootTableEntry()
            {
                Item = new Item(new ItemTemplate(){}),
                Weight = 0f
            },
            new LootTableEntry()
            {
                Item = new Item(new ItemTemplate(){}),
                Weight = 0f
            }
        };
        
        var loot = _lootTable.GetLoot();
        Assert.IsTrue(loot == null);
    }
}