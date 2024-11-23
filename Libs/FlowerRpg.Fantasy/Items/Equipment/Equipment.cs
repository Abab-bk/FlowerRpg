using FlowerRpg.Items;
using FlowerRpg.Stats;

namespace FlowerRpg.Fantasy.Items.Equipment;

public class Equipment(ItemTemplate itemTemplate) : AffixItem(itemTemplate), IEquipment
{
    public IEquipmentSlots Slots { get; } = new EquipmentSlots();
    
    public void Equip(IEnumerable<IStat> stats)
    {
        base.Use();
        Active = true;
        ApplyAffixes(stats);
    }

    public void Release(IEnumerable<IStat> stats)
    {
        RemoveAffixes(stats);
        Active = false;
    }
}