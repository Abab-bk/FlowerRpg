using FlowerRpg.Items;

namespace FlowerRpg.Starter.Items;

public class Item : IItem
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Desc { get; set; } = string.Empty;
}