using FlowerRpg.Stats;

namespace FlowerRpg.Fantasy.Items.Affixes;

public abstract class Affix
{
    public string Name { get; set; } = "";
    public string Desc { get; set; } = "";
    public List<float> Values { get; set; } = new ();

    public virtual void Apply(IEnumerable<IStat> stats)
    {
    }
    
    public virtual void Remove(IEnumerable<IStat> stats)
    {
    }
}