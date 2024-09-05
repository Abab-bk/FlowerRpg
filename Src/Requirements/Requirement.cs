using FlowerRpg.Interfaces;

namespace FlowerRpg.Requirements;

public class Requirement : IHasAssociation
{
    public int RequirementType { get; set; }
    public int AssociatedId { get; set; }
    public int AssociatedValue { get; set; }
}