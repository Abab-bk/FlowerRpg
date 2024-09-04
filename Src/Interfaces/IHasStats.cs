using FlowerRpg.Stats;

namespace FlowerRpg.Interfaces;

public interface IHasStats<T> where T : IStatsData
{
    public T StatsData { get; }
}