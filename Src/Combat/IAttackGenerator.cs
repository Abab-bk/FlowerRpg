using FlowerRpg.Stats;

namespace FlowerRpg.Combat;

public interface IAttackGenerator
{
    public Attack GenerateAttack(IEnumerable<IStat> stats);
}