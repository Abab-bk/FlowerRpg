namespace FlowerRpg.Core.Requirements;

public struct Requirement : IHasAssociation
{
    public int RequirementType { get; set; }
    public int AssociatedId { get; set; }
    public int AssociatedValue { get; set; }
}