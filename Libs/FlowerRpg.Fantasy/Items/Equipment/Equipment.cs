using FlowerRpg.Fantasy.Classes;
using FlowerRpg.Items;

namespace FlowerRpg.Fantasy.Items.Equipment;

public class Equipment(ItemTemplate itemTemplate) : AffixItem(itemTemplate), IEquipment
{
    public IEquipmentSlots Slots { get; } = new EquipmentSlots();
    
    public void Equip(CharacterStats stats)
    {
        base.Use();
        Active = true;
        ApplyAffixes(stats);
    }

    public void Release(CharacterStats stats)
    {
        RemoveAffixes(stats);
        Active = false;
    }
}