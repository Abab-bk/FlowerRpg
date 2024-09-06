using FlowerRpg.Stats;

namespace FlowerRpg.Fantasy.Effects;

public class ModifierEffect(Stat stat, ModifierType modifierType) : Effect(stat, modifierType)
{
    public override void Apply()
    {
        stat.AddModifier(new StatModifier(
            Potency,
            modifierType,
            this
        ));
    }
    
    public override void Remove()
    {
        stat.RemoveAllModifiersFromSource(this);
    }
}