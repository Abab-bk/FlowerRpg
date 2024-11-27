namespace FlowerRpg.Items;

public interface IItem
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Desc { get; set; }
}