using FlowerRpg.Fantasy.Enums;
using FlowerRpg.Fantasy.Util;

namespace FlowerRpg.Fantasy.Items.Equipment.Slots;

public class ChestSlot : EquipmentSlot
{
    public override bool CanEquipItemType(int itemType)
    {
        return itemType == (int)ItemType.Chest;
    }
}

public class HeadSlot : EquipmentSlot
{
    public override bool CanEquipItemType(int itemType)
    {
        return itemType == (int)ItemType.Head;
    }
}

public class BootsSlot : EquipmentSlot
{
    public override bool CanEquipItemType(int itemType)
    {
        return itemType == (int)ItemType.Boots;
    }
}

public class GlovesSlot : EquipmentSlot
{
    public override bool CanEquipItemType(int itemType)
    {
        return itemType == (int)ItemType.Gloves;
    }
}

public class PantsSlot : EquipmentSlot
{
    public override bool CanEquipItemType(int itemType)
    {
        return itemType == (int)ItemType.Pants;
    }
}

public class RingSlot : EquipmentSlot
{
    public override bool CanEquipItemType(int itemType)
    {
        return itemType == (int)ItemType.Ring;
    }
}

public class AmuletSlot : EquipmentSlot
{
    public override bool CanEquipItemType(int itemType)
    {
        return itemType == (int)ItemType.Amulet;
    }
}

public class WeaponSlot : EquipmentSlot
{
    public override bool CanEquipItemType(int itemType)
    {
        return TypesHelper.IsWeapon((ItemType)itemType);
    }
}