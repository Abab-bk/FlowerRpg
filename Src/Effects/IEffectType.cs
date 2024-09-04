using FlowerRpg.Interfaces;
using FlowerRpg.Stats;

namespace FlowerRpg.Effects;

public interface IEffectType<in T> where T : IStatsData
{
    public Func<T, IModifiable<float>> Data { get; }
}