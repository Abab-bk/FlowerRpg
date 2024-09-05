using FlowerRpg.Stats;

namespace FlowerRpg.Fantasy.Classes.Affixes;

public class SimpleAffix : Affix
{
    public Stat TargetStat;
    public ModifierType ModifierType;
    
    public override void Apply(CharacterStats stats)
    {
        if (TargetStat == null) return;
        base.Apply(stats);
        TargetStat.AddModifier(new StatModifier(Values[0], ModifierType, this));
    }

    public override void Remove(CharacterStats stats)
    {
        base.Remove(stats);
        TargetStat?.RemoveAllModifiersFromSource(this);
    }
}