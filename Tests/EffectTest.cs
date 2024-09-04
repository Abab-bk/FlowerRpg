using FlowerRpg.Effects;
using FlowerRpg.Fantasy.Classes.Characters;
using FlowerRpg.Fantasy.Classes.Classes;
using FlowerRpg.Fantasy.Classes.Races;
using FlowerRpg.Fantasy.Effects;
using FlowerRpg.Interfaces;
using FlowerRpg.Stats;

namespace Tests;

public class EffectTest
{
    private Character _character;
    
    [SetUp]
    public void Setup()
    {
        _character = new Character(
            new List<IClass>()
            {
                new Warrior()
            },
            new Human(),
            new List<Effect>()
            )
        {
            StatsData = { Health = new Stat<float>(100)}
        };
    }
    
    [Test]
    public void AddEffect()
    {
        _character.AddEffect(new Effect()
        {
            EffectType = EffectType.HealthBonusFlat,
            Potency = 10f
        });
        Assert.That(_character.StatsData.Health.Value, Is.EqualTo(110f));
    }
}