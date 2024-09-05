using FlowerRpg.Interfaces;
using FlowerRpg.Inventory;

namespace FlowerRpg.Items;

public interface IItem : IHasItemTemplate<IItemTemplate>
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Desc { get; set; }
}