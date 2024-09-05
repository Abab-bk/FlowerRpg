using FlowerRpg.Effects;
using FlowerRpg.Stats;

namespace FlowerRpg.Fantasy.Effects;

public class Effect(Stat stat, ModifierType modifierType) : IEffect
{
    public float Potency { get; set; }
    public Stat Data => stat;
    
    public void Apply()
    {
        stat.AddModifier(new StatModifier(
            Potency,
            modifierType,
            this
        ));
    }
    
    public void Remove()
    {
        stat.RemoveAllModifiersFromSource(this);
    }
}