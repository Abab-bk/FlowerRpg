using FlowerRpg.Combat;
using FlowerRpg.Fantasy.Classes;
using FlowerRpg.Stats;

namespace FlowerRpg.Fantasy.Combat;

public class BasicAttackGenerator : IAttackGenerator
{
    public Attack GenerateAttack(IEnumerable<IStat> stats)
    {
        // return new Attack(
        //     stats.GetDamageStats()
        //         .Where(x => x.Value != 0)
        //         .Select(x => new Damage(x.StatType, x.Value))
        //         .ToArray()
        // );
        throw new NotImplementedException();
    }
}