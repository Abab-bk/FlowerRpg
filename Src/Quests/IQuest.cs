using FlowerRpg.Core;
using FlowerRpg.Core.Requirements;
using FlowerRpg.Items;

namespace FlowerRpg.Quests;

public interface IQuest
{
    public int Id { get; }
    public string Name { get; }
    public string Description { get; }
    public bool IsRepeatable { get; }
    
    public IEnumerable<Requirement> Requirements { get; }
    public IEnumerable<Requirement> Objectives { get; }
    public IEnumerable<Reward> Rewards { get; }
    public IEnumerable<IItem> Consumables { get; }
    
    public bool IsCompleted { get; }
    public bool CanComplete();
    public bool TryComplete();
    public bool TryStart();
    public bool TryReset();
}