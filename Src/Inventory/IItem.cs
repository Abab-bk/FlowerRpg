namespace FlowerRpg.Inventory;

public interface IItem
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Desc { get; set; }
    public IItemTemplate Template { get; set; }
}