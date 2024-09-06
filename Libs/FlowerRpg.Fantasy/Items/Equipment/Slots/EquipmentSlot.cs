using FlowerRpg.Items;

namespace FlowerRpg.Fantasy.Items.Equipment.Slots;

public abstract class EquipmentSlot : IEquipmentSlot
{
    public IItem SlottedItem { get; set; }

    public abstract bool CanEquipItemType(int itemType);

    public IItem UnequipItem()
    {
        throw new NotImplementedException();
    }

    public bool EquipItemToSlot(IItem item)
    {
        throw new NotImplementedException();
    }
}