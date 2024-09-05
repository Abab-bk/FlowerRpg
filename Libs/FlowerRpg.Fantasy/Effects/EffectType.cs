using FlowerRpg.Effects;
using FlowerRpg.Fantasy.Classes;
using FlowerRpg.Stats;

namespace FlowerRpg.Fantasy.Effects;

public class EffectType(Stat stat, ModifierType modifierType)
    : IEffectType<CharacterStats>
{
    public Stat Data => stat;

    public void Apply(float value)
    {
        stat.AddModifier(new StatModifier(
            value,
            modifierType,
            this
            ));
    }
    
    public void Remove()
    {
        stat.RemoveAllModifiersFromSource(this);
    }
}