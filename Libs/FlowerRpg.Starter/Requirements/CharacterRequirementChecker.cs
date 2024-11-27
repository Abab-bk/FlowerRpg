using FlowerRpg.Core.Requirements;
using FlowerRpg.Starter.Characters;
using FlowerRpg.Starter.Stats;

namespace FlowerRpg.Starter.Requirements;

public static class CharacterRequirementChecker
{
    public static bool IsRequirementMet(Character target, Requirement requirement)
    {
        switch (requirement.RequirementType)
        {
            case RequirementTypes.LevelLargerRequirement:
                return target.Stats.GetStat(StatType.Level).Value >= requirement.AssociatedValue;
        }
        return false;
    }
}