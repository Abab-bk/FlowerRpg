using FlowerRpg.Core;
using FlowerRpg.Core.Requirements;

namespace FlowerRpg.Quests;

public interface IQuest
{
    public int Id { get; }
    public string Name { get; }
    public string Description { get; }
    public bool IsRepeatable { get; }
    
    public IEnumerable<Requirement> Requirements { get; }
    public IEnumerable<Objective> Objectives { get; }
    public IEnumerable<Reward> Rewards { get; }
}