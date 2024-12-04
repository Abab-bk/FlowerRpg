using FlowerRpg.Items;
using FlowerRpg.Starter.Items;
using FlowerRpg.Starter.Items.Inventory;
using Moq;

namespace Tests;

public class StackInventoryTests
{
    [Fact]
    public void AddItem_WhenInventoryHasSpace_AddsNewItemStack()
    {
        var itemMock = new Mock<IItem>();
        var item = itemMock.Object;
        var inventory = new StackInventory(10);

        var added = inventory.AddItem(item, 3);

        Assert.True(added);
        Assert.Single(inventory.GetItems());
        Assert.Equal(item, inventory.GetItems().First().Item);
    }

    [Fact]
    public void AddItem_WhenInventoryExceedsCapacity_DoesNotAdd()
    {
        var itemMock = new Mock<IItem>();
        var item = itemMock.Object;
        var inventory = new StackInventory(1);

        inventory.AddItem(item, 1); // fill up the inventory
        var added = inventory.AddItem(item, 1);

        Assert.False(added);
        Assert.Equal(1, inventory.GetUsedCapacity());
    }

    [Fact]
    public void AddItem_WhenItemStackExists_AddToExistingStack()
    {
        var itemMock = new Mock<IItem>();
        var item = itemMock.Object;
        var itemStackMock = new Mock<IItemStack>();
        itemStackMock.Setup(x => x.Item).Returns(item);
        itemStackMock.Setup(x => x.CanAdd(1)).Returns(true);
        itemStackMock.Setup(x => x.Add(It.IsAny<int>())).Returns(true);

        var inventory = new StackInventory();
        inventory.AddItem(itemStackMock.Object.Item);

        var added = inventory.AddItem(item, 3);

        Assert.True(added);
    }

    [Fact]
    public void RemoveItem_WhenItemExists_RemovesItemFromStack()
    {
        var itemMock = new Mock<IItem>();
        var item = itemMock.Object;
        var itemStackMock = new Mock<IItemStack>();
        itemStackMock.Setup(x => x.Item).Returns(item);
        itemStackMock.Setup(x => x.Remove(It.IsAny<int>())).Returns(true);

        var inventory = new StackInventory();
        inventory.AddItem(itemMock.Object);

        var removed = inventory.RemoveItem(item, 2);

        Assert.True(removed);
    }

    [Fact]
    public void RemoveItem_WhenItemDoesNotExist_ReturnsFalse()
    {
        var itemMock = new Mock<IItem>();
        var item = itemMock.Object;
        var inventory = new StackInventory();

        var removed = inventory.RemoveItem(item, 1);

        Assert.False(removed);
    }

    [Fact]
    public void PopItem_WhenItemIdExists_RemovesItemAndReturnsIt()
    {
        var item = new Item { Id = 1 };
        var inventory = new StackInventory();
        inventory.AddItem(item);

        var poppedItem = inventory.PopItem(1);

        Assert.NotNull(poppedItem);
        item.Equals(poppedItem);
    }

    [Fact]
    public void PopItem_WhenItemIdDoesNotExist_ReturnsNull()
    {
        var itemMock = new Mock<IItem>();
        itemMock.Setup(x => x.Id).Returns(1);
        var inventory = new StackInventory();

        var poppedItem = inventory.PopItem(1);

        Assert.Null(poppedItem);
    }

    [Fact]
    public void GetItems_ReturnsAllStoredItems()
    {
        var itemMock = new Mock<IItem>();
        var itemStackMock = new Mock<IItemStack>();
        itemStackMock.Setup(x => x.Item).Returns(itemMock.Object);

        var inventory = new StackInventory();
        inventory.AddItem(itemStackMock.Object.Item);
        
        Assert.NotEmpty(inventory.GetItems());
        Assert.Equal(itemMock.Object, inventory.GetItems().First().Item);
    }
}