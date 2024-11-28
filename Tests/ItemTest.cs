using FlowerRpg.Items;
using FlowerRpg.Starter.Items;

namespace Tests;

public class ItemTest
{
    private IEquipment _item;
    private IItemSlots _itemSlots;

    private const int Slot1 = 1;
    private const int Slot2 = 2;

    [SetUp]
    public void Setup()
    {
        _item = new Equipment
        {
            Id = 1001,
            Name = "Test Item",
            Desc = "Test Item Description",
            Slots = []
        };

        _itemSlots = new ItemSlots
        {
            AcceptSlots = [Slot1, Slot2]
        };
    }

    [Test]
    public void CanPlaceItem_Return_False()
    {
        Assert.That(_itemSlots.CanPlaceItem(_item), Is.EqualTo(false));
    }

    [Test]
    public void CanPlaceItem_Return_True()
    {
        _item.Slots = [Slot1];
        Assert.That(_itemSlots.CanPlaceItem(_item), Is.EqualTo(true));
    }

    [Test]
    public void TryPlaceItem_HasItem_Return_True()
    {
        _item.Slots = [Slot1];
        _itemSlots.TryPlaceItem(_item);
        Assert.That(_itemSlots.HasItem(), Is.EqualTo(true));
    }

    [Test]
    public void RemoveItem_HasItem_Return_False()
    {
        _item.Slots = [Slot1];
        _itemSlots.TryPlaceItem(_item);
        _itemSlots.RemoveItem();
        Assert.That(_itemSlots.HasItem(), Is.EqualTo(false));
    }
}