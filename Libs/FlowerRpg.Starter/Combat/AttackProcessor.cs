using FlowerRpg.Combat;
using FlowerRpg.Starter.Stats;
using FlowerRpg.Stats;

namespace FlowerRpg.Starter.Combat;

public class AttackProcessor : IAttackProcessor
{
    public ProcessedAttack ProcessAttack(Attack attack, IStats stats)
    {
        var totalDamage = attack.Damages.Sum(x => x.Value);
        var defense = stats.GetStat((int)StatType.Defense).Value;
        var damageDone = new Damage(DamageType.Normal, totalDamage - defense);
        var defenseDone = new Damage(DamageType.Normal, defense);
        return new ProcessedAttack([damageDone], [defenseDone]);
    }
}