namespace FlowerRpg.Requirements;

public interface IRequirementChecker<in T>
{
    public bool IsRequirementMet(T target, Requirement requirement);
}