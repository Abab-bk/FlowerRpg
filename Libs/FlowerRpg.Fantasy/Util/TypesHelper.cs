using FlowerRpg.Fantasy.Enums;

namespace FlowerRpg.Fantasy.Util;

public static class TypesHelper
{
    public static bool IsEquipment(ItemType itemType)
    {
        if (IsWeapon(itemType)) return true;
        if (IsArmor(itemType)) return true;
        return false;
    }

    public static bool IsWeapon(ItemType itemType) => itemType switch
    {
        ItemType.Sword => true,
        ItemType.TwoHandedSword => true,
        ItemType.Axe => true,
        ItemType.TwoHandedAxe => true,
        ItemType.Hammer => true,
        ItemType.TwoHandedHammer => true,
        ItemType.Mace => true,
        ItemType.TwoHandedMace => true,
        ItemType.Dagger => true,
        ItemType.Shield => true,
        ItemType.Bow => true,
        _ => false
    };

    public static bool IsArmor(ItemType itemType) => itemType switch
    {
        ItemType.Head => true,
        ItemType.Chest => true,
        ItemType.Boots => true,
        ItemType.Gloves => true,
        ItemType.Pants => true,
        ItemType.Ring => true,
        ItemType.Amulet => true,
        _ => false
    };
}