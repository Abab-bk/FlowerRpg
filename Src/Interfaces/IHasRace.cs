using FlowerRpg.Interfaces;

namespace FlowerRpg.Effects;

public interface IHasRace<T> where T : IRace
{
    public event Action<T> OnRaceSet;
    public T Race { get; }
    public void SetRace(T race);
}