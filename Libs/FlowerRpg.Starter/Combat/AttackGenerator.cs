using FlowerRpg.Combat;
using FlowerRpg.Starter.Stats;
using FlowerRpg.Stats;

namespace FlowerRpg.Starter.Combat;

public class AttackGenerator : IAttackGenerator
{
    public Attack GenerateAttack(IStats stats)
    {
        return new Attack(
            [
                new Damage(DamageType.Normal, stats.GetStat((int)StatType.Damage).Value)
            ]
            );
    }
}