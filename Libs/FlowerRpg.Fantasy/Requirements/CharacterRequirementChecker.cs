using FlowerRpg.Fantasy.Characters;
using FlowerRpg.Requirements;

namespace FlowerRpg.Fantasy.Requirements;

public class CharacterRequirementChecker : IRequirementChecker<Character>
{
    public virtual bool IsRequirementMet(Character target, Requirement requirement)
    {
        throw new NotImplementedException();
    }
}