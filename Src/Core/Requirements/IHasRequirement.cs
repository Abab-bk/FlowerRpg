namespace FlowerRpg.Core.Requirements;

public interface IHasRequirement
{
    public IEnumerable<Requirement> Requirements { get; }
}