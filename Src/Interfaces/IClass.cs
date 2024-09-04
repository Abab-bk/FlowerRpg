namespace FlowerRpg.Interfaces;

public interface IClass
{
    public int Id { get; set; }
    public string Name { get; set; }

    public void RemoveSelf();
}