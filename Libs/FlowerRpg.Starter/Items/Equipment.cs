using FlowerRpg.Items;

namespace FlowerRpg.Starter.Items;

public class Equipment : Item, IEquipment
{
    public IEnumerable<int> Slots { get; set; } = new List<int>();
    public IItem Item => this;
}