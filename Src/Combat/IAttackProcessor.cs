using FlowerRpg.Stats;

namespace FlowerRpg.Combat;

public interface IAttackProcessor
{
    public ProcessedAttack ProcessAttack(Attack attack, IStats stats);
}