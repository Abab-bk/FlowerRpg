using FlowerRpg.Core;
using FlowerRpg.Core.Requirements;

namespace FlowerRpg.Quests;

public class Quest
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public bool IsRepeatable { get; set; }
    
    public List<Requirement> Requirements { get; set; }
    public List<Objective> Objectives { get; set; }
    public List<Reward> Rewards { get; set; }
}