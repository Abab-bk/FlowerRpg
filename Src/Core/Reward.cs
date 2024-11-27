namespace FlowerRpg.Core;

public class Reward : IHasAssociation
{
    public string Name { get; set; }
    public int RewardType { get; set; }
    
    public int AssociatedId { get; set; }
    public int AssociatedValue { get; set; }
}