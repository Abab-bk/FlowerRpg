namespace FlowerRpg.Fantasy.Classes.Affixes;

public class Affix
{
    public string Name { get; set; } = "";
    public string Desc { get; set; } = "";
    public List<float> Values { get; set; } = new ();

    public virtual void Apply(CharacterStats stats)
    {
    }
    
    public virtual void Remove(CharacterStats stats)
    {
    }
}