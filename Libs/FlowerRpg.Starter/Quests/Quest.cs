using FlowerRpg.Core;
using FlowerRpg.Core.Requirements;
using FlowerRpg.Items;
using FlowerRpg.Quests;
using FlowerRpg.Starter.Extensions;
using FlowerRpg.Starter.Requirements;

namespace FlowerRpg.Starter.Quests;

public class Quest : IQuest
{
    public event Action OnComplete = delegate { };
    public event Action<IEnumerable<IItem>> OnConsume = delegate { }; 
    
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    
    public bool IsRepeatable { get; set; }
    
    public IEnumerable<Requirement> Requirements { get; set; } = Array.Empty<Requirement>();
    public IEnumerable<Requirement> Objectives { get; set; } = Array.Empty<Requirement>();
    public IEnumerable<Reward> Rewards { get; set; } = Array.Empty<Reward>();
    public IEnumerable<IItem> Consumables { get; set; } = Array.Empty<IItem>();

    public bool IsCompleted { get; private set; }

    public bool CanComplete() => Objectives.All(RequirementChecker.IsRequirementMet);
    public bool CanStart() => Requirements.All(RequirementChecker.IsRequirementMet);

    public bool TryStart()
    {
        if (!CanStart()) return false;
        IsCompleted = false;
        return true;
    }

    public bool TryComplete()
    {
        if (!CanComplete()) return false;
        Complete();
        return true;
    }
    
    public bool TryReset()
    {
        if (!IsRepeatable) return false;
        IsCompleted = false;
        return true;
    }
    
    private void Complete()
    {
        IsCompleted = true;
        OnComplete.Invoke();
        GetRewards();
        ConsumeItems();
    }

    private void GetRewards()
    {
        foreach (var reward in Rewards)
        {
            reward.GetReward();
        }
    }
    
    private void ConsumeItems()
    {
        OnConsume.Invoke(Consumables);
    }
}