using FlowerRpg.Items;

namespace FlowerRpg.Fantasy.Items.Equipment;

public class EquipmentSlots : IEquipmentSlots
{
    public IEnumerable<int> Slots { get; }
}