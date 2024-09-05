using FlowerRpg.Combat;
using FlowerRpg.Fantasy.Classes;

namespace FlowerRpg.Fantasy.Combat;

public class BasicAttackGenerator : IAttackGenerator<CharacterStats>
{
    public Attack GenerateAttack(CharacterStats stats)
    {
        return new Attack(
            stats.GetDamageStats()
            .Where(x => x.Value != 0)
            .Select(x => new Damage(x.StatType, x.Value))
            .ToArray()
            );
    }
}