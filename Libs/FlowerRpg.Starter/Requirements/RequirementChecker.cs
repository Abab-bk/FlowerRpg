using FlowerRpg.Core.Requirements;

namespace FlowerRpg.Starter.Requirements;

public static class RequirementChecker
{
    public static bool IsRequirementMet(Requirement requirement)
    {
        switch (requirement.RequirementType)
        {
            case RequirementTypes.LevelLargerRequirement:
                return CharacterRequirementChecker.IsRequirementMet(
                    RpgManager.Instance.Player, requirement
                    );
        }
        return false;
    }
}