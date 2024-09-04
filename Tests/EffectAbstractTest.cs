using FlowerRpg.Fantasy.Classes.Characters;
using FlowerRpg.Fantasy.Classes.Classes;
using FlowerRpg.Fantasy.Classes.Races;
using FlowerRpg.Fantasy.Effects;
using FlowerRpg.Interfaces;
using FlowerRpg.Stats;

namespace Tests;

public class EffectAbstractTest
{
    private Character _character;
    
    [SetUp]
    public void Setup()
    {
        _character = new Character(
            new List<BaseClass>()
            {
                new BaseClass()
            },
            new BaseRace(),
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
            EffectType = new EffectType(statsData => statsData.Health.flat.modifiers),
            Potency = 10f
        });
        Assert.That(_character.StatsData.Health.Value, Is.EqualTo(110f));
    }
}