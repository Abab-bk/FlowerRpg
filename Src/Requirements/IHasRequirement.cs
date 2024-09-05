namespace FlowerRpg.Requirements;

public interface IHasRequirement
{
    public IEnumerable<Requirement> Requirements { get; }
}