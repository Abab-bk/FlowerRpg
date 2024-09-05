using FlowerRpg.Fantasy.Characters;
using FlowerRpg.Requirements;

namespace FlowerRpg.Fantasy.Requirements;

public class CharacterRequirementChecker : IRequirementChecker<Character>
{
    public virtual bool IsRequirementMet(Character target, Requirement requirement)
    {
        switch (requirement.RequirementType)
        {
            case (int)RequirementType.StrengthRequirement:
                return target.StatsData.Strength.Value >= requirement.AssociatedValue;
            case (int)RequirementType.DexterityRequirement:
                return target.StatsData.Dexterity.Value >= requirement.AssociatedValue;
            case (int)RequirementType.ConstitutionRequirement:
                return target.StatsData.Constitution.Value >= requirement.AssociatedValue;
            case (int)RequirementType.IntelligenceRequirement:
                return target.StatsData.Intelligence.Value >= requirement.AssociatedValue;
            case (int)RequirementType.WisdomRequirement:
                return target.StatsData.Wisdom.Value >= requirement.AssociatedValue;
            case (int)RequirementType.CharismaRequirement:
                return target.StatsData.Charisma.Value >= requirement.AssociatedValue;
            case (int)RequirementType.LevelRequirement:
                return target.StatsData.Level.Value >= requirement.AssociatedValue;
            case (int)RequirementType.HealthRequirement:
                return target.StatsData.Health.Value >= requirement.AssociatedValue;
            case (int)RequirementType.ManaRequirement:
                return target.StatsData.Mana.Value >= requirement.AssociatedValue;
            default:
                return false;
        }
    }
}