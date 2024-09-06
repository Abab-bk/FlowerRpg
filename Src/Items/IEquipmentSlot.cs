namespace FlowerRpg.Items;

public interface IEquipmentSlot
{
    public IItem SlottedItem { get; }

    public bool CanEquipItemType(int itemType);
    
    /// <summary>
    /// Unequip an item from the slot
    /// </summary>
    /// <returns>Returns the item that was equipped, or null if nothing was equipped</returns>
    public IItem UnequipItem();
    
    /// <summary>
    /// Equips and item to the slot, if an item is already in the slot it needs unequipping explicitly first
    /// </summary>
    /// <param name="item">The item to equip</param>
    /// <returns>True if it was empty and can be equipped, false if it cannot be equipped or an item is already equipped</returns>
    public bool EquipItemToSlot(IItem item);
}