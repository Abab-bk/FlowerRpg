namespace FlowerRpg.Classes;

public interface IClass
{
    public int Id { get; set; }
    public string Name { get; set; }

    public void RemoveSelf();
}