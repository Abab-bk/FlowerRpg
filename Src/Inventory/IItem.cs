using FlowerRpg.Interfaces;

namespace FlowerRpg.Inventory;

public interface IItem : IHasItemTemplate<IItemTemplate>
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Desc { get; set; }
}