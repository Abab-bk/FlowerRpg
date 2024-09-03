using FlowerRpg.Fantasy.Enums;
using FlowerRpg.Fantasy.Inventory;

namespace Tests;

public class ItemTest
{
    private Item _propItem;

    [SetUp]
    public void Setup()
    {
        _propItem = new Item(new ItemTemplate()
        {
            ItemType = ItemType.Prop
        })
        {
            MaxStack = 2
        };
    }

    [Test]
    [TestCase(2)]
    [TestCase(-3)]
    [TestCase(0)]
    public void WithMaxStack(int added)
    {
        var item = _propItem.Clone().WithMaxStack(added);
        if (added + 2 <= 0)
        {
            Assert.That(item.MaxStack, Is.EqualTo(1));
            return;
        }

        Assert.That(item.MaxStack, Is.EqualTo(2 + added));
    }

    [Test]
    public void AddQuantity_Over_Stack_Return_False()
    {
        var item = _propItem.Clone();
        Assert.IsTrue(item.AddQuantity(1));
        Assert.IsFalse(item.AddQuantity(1));
    }
    
    [Test]
    public void TryAddQuantity_Over_Stack_Return_False()
    {
        var item = _propItem.Clone();
        Assert.IsTrue(item.TryAddQuantity(1, out _));
        Assert.IsFalse(item.TryAddQuantity(1, out var needAdded));
        Assert.That(needAdded, Is.EqualTo(1));

        var item2 = _propItem.Clone();
        Assert.IsTrue(item2.TryAddQuantity(10, out var needAdded2));
        Assert.That(needAdded2, Is.EqualTo(9));
    }

    [Test]
    public void RemoveQuantity_Over_Stack_Return_True()
    {
        var item = _propItem.Clone();
        item.AddQuantity(1);
        item.RemoveQuantity(1);
        Assert.That(item.Quantity, Is.EqualTo(1));
    }

    [Test]
    public void RemoveQuantity_All_Event()
    {
        var item = _propItem.Clone();
        item.OnRemoved += Assert.Pass;
        item.RemoveQuantity(2);
    }
}