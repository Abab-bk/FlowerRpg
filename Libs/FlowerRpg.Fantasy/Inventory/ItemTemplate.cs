using FlowerRpg.Fantasy.Enums;
using FlowerRpg.Inventory;

namespace FlowerRpg.Fantasy.Inventory;

public class ItemTemplate : IItemTemplate
{
    public int Id { get; set; }
    public string Name { get; set; } = "";
    public string Desc { get; set; } = "";
    public ItemType ItemType { get; set; }
    public QualityType QualityType { get; set; }
}