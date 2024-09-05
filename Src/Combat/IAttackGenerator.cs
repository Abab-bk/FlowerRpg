using FlowerRpg.Interfaces;

namespace FlowerRpg.Combat;

public interface IAttackGenerator<in T> where T : IStatsData
{
    public Attack GenerateAttack(T stats);
}