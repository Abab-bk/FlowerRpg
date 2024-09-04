using FlowerRpg.Effects;

namespace FlowerRpg.Interfaces;

/// <summary>
/// A character.
/// </summary>
public interface ICharacter<T> : IHasEffect, IHasStats<T> where T : IStatsData
{
    public event Action<IClass> OnClassAdded;
    public event Action<IClass> OnClassRemoved;
    public event Action<IRace> OnRaceSet;
    
    public int Id { get; set; }
    public string Name { get; set; }
    
    public List<IClass> Classes { get; }
    public IRace Race { get; }
    
    public void AddClass(IClass @class);
    public void RemoveClass(IClass @class);
    public bool HasClass(IClass @class);
    
    public void SetRace(IRace race);
}