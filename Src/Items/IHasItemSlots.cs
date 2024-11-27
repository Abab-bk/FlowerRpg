namespace FlowerRpg.Items;

public interface IHasItemSlots
{
    public IEnumerable<int> Slots { get; set; }
    public IItem Item { get; }
}