using FlowerRpg.Interfaces;

namespace FlowerRpg.Combat;

public interface IAttackProcessor<in T> where T : IStatsData
{
    public ProcessedAttack ProcessAttack(Attack attack, T stats);
}