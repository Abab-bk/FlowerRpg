using FlowerRpg.Stats;

namespace FlowerRpg.Fantasy.Items.Affixes;

public class SimpleAffix : Affix
{
    public Stat TargetStat;
    public ModifierType ModifierType;
    
    public override void Apply(IEnumerable<IStat> stats)
    {
        if (TargetStat == null) return;
        base.Apply(stats);
        // TargetStat.AddModifier(new StatModifier(Values[0], ModifierType, this));
    }

    public override void Remove(IEnumerable<IStat> stats)
    {
        base.Remove(stats);
        TargetStat?.RemoveAllModifiersFromSource(this);
    }
}