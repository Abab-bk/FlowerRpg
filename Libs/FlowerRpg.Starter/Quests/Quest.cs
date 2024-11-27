using FlowerRpg.Core;
using FlowerRpg.Core.Requirements;
using FlowerRpg.Quests;

namespace FlowerRpg.Starter.Quests;

public class Quest : IQuest
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    
    public bool IsRepeatable { get; set; }
    
    public IEnumerable<Requirement> Requirements { get; set; } = Array.Empty<Requirement>();
    public IEnumerable<Objective> Objectives { get; set; } = Array.Empty<Objective>();
    public IEnumerable<Reward> Rewards { get; set; } = Array.Empty<Reward>();
}