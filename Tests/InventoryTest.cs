using FlowerRpg.Fantasy.Enums;
using FlowerRpg.Fantasy.Inventory;
using FlowerRpg.Fantasy.Items;

namespace Tests;

public class InventoryTest
{
    private Item _weaponItem;
    private Item _propItem;
    
    [SetUp]
    public void Setup()
    {
        _weaponItem = new Item(new ItemTemplate
        {
            ItemType = ItemType.Sword,
            QualityType = QualityType.Common
        });
        _propItem = new Item(new ItemTemplate
        {
            ItemType = ItemType.Prop,
            QualityType = QualityType.Common
        });
    }
    
    [Test]
    public void AddItem_Weapon_Item_Return_True()
    {
        var inventory = new StackInventory(10);
        Assert.IsTrue(inventory.AddItem(_weaponItem));
    }

    [Test]
    public void AddItem_Over_Stack_Return_False()
    {
        var inventory = new StackInventory(1);
        Assert.IsTrue(inventory.AddItem(_weaponItem));
        Assert.IsFalse(inventory.AddItem(_weaponItem));
    }
    
    [Test]
    public void AddItem_Over_Stack_Return_True()
    {
        var inventory = new StackInventory(2);
        Assert.IsTrue(inventory.AddItem(_weaponItem));
        Assert.IsTrue(inventory.AddItem(_weaponItem));
    }
    
    [Test]
    public void RemoveItem_Prop_Item()
    {
        var inventory = new StackInventory(10);
        inventory.AddItem(_propItem);
        Assert.IsTrue(inventory.HasItem(_propItem));
        inventory.RemoveItem(_propItem);
        Assert.IsFalse(inventory.HasItem(_propItem));
    }

    [Test]
    public void GetAllItemCount_Should_Be()
    {
        var inventory = new StackInventory(10);
        var item = _weaponItem.Clone();
        inventory.AddItem(item);
        Assert.That(inventory.GetAllItemCount(), Is.EqualTo(1));
        inventory.AddItem(item);
        Assert.That(inventory.GetAllItemCount(), Is.EqualTo(2));
    }

    [Test]
    public void AddItem_If_ItemExists_Create_NewOne()
    {
        var inventory = new StackInventory(2);
        var item = _propItem.Clone();
        inventory.AddItem(item);
        Assert.That(inventory.GetAllItemCount(), Is.EqualTo(1));
        inventory.AddItem(item);
        Assert.That(inventory.GetAllItemCount(), Is.EqualTo(2));
        Assert.IsFalse(inventory.AddItem(item));
    }
}