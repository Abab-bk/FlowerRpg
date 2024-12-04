namespace FlowerRpg.Items;

public interface IItem
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Desc { get; set; }
    public int MaxStack { get; set; }

    public IItem Clone();
}