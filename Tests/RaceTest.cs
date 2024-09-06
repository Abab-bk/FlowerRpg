using FlowerRpg.Fantasy.Characters;
using FlowerRpg.Fantasy.Effects;
using FlowerRpg.Fantasy.Races;
using FlowerRpg.Stats;

namespace Tests;

public class RaceTest
{
    private (Character, BaseRace) NewCharacterWithRace()
    {
        var race = new BaseRace();
        var character = new Character([], race, []);
        return (character, race);
    }

    [Test]
    public void Remove_When_Has_Effect()
    {
        var (character, race) = NewCharacterWithRace();
        race.AddEffect(new ModifierEffect(character.StatsData.Strength, ModifierType.Flat) { Potency = 10f });
        Assert.That(character.StatsData.Strength.Value, Is.EqualTo(10f));
        race.RemoveSelf();
        Assert.That(character.StatsData.Strength.Value, Is.EqualTo(0f));
    }
}