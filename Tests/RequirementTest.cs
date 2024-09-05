using FlowerRpg.Fantasy.Characters;
using FlowerRpg.Fantasy.Effects;
using FlowerRpg.Fantasy.Races;
using FlowerRpg.Fantasy.Requirements;
using FlowerRpg.Requirements;
using FlowerRpg.Stats;

namespace Tests;

public class RequirementTest
{
    private Character _character;
    
    [SetUp]
    public void Setup()
    {
        _character = new Character([], new BaseRace(), []);
    }
    
    [Test]
    public void IsRequirementMet_Return_False()
    {
        Assert.IsTrue(new CharacterRequirementChecker().IsRequirementMet(_character, new Requirement()
        {
            RequirementType = (int)RequirementType.StrengthRequirement,
            AssociatedValue = 0
        }));
    }
    
    [Test]
    public void IsRequirementMet_Return_True()
    {
        _character.AddEffect(new Effect(_character.StatsData.Strength, ModifierType.Flat)
        {
            Potency = 10f
        });
        Assert.IsTrue(new CharacterRequirementChecker().IsRequirementMet(_character, new Requirement()
        {
            RequirementType = (int)RequirementType.StrengthRequirement,
            AssociatedValue = 10
        }));
    }
}