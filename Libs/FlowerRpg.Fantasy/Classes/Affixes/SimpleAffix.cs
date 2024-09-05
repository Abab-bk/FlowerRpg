using FlowerRpg.Stats;

namespace FlowerRpg.Fantasy.Classes.Affixes;

public class SimpleAffix : Affix
{
    public Stat Target;
    public ModifierType ModifierType;
    
    public override void Apply(CharacterStats stats)
    {
        if (Target == null) return;
        base.Apply(stats);
        Target.AddModifier(new StatModifier(Values[0], ModifierType, this));
    }
}