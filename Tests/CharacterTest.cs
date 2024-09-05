using FlowerRpg.Fantasy.Characters;
using FlowerRpg.Fantasy.Classes;
using FlowerRpg.Fantasy.Effects;
using FlowerRpg.Fantasy.Races;
using FlowerRpg.Stats;

namespace Tests;

public class CharacterTest
{
    private Character _character;
    
    [SetUp]
    public void Setup()
    {
        _character = new Character(
            [],
            new BaseRace(),
            []
        );
    }
    
    [Test]
    public void AddClass()
    {
        var baseClass = new BaseClass();
        baseClass.AddEffect(new Effect(_character.StatsData.Strength, ModifierType.Flat) { Potency = 100f });
        _character.AddClass(baseClass);
        Assert.That(_character.StatsData.Strength.Value, Is.EqualTo(100f));
    }
    
    [Test]
    public void RemoveClass()
    {
        var baseClass = new BaseClass();
        baseClass.AddEffect(new Effect(_character.StatsData.Strength, ModifierType.Flat) { Potency = 100f });
        _character.AddClass(baseClass);
        _character.RemoveClass(baseClass);
        Assert.That(_character.StatsData.Strength.Value, Is.EqualTo(0f));
    }
    
    [Test]
    public void HasClass()
    {
        var baseClass = new BaseClass();
        baseClass.AddEffect(new Effect(_character.StatsData.Strength, ModifierType.Flat) { Potency = 100f });
        _character.AddClass(baseClass);
        Assert.That(_character.HasClass(baseClass), Is.True);
    }
    
    [Test]
    public void SetRace()
    {
        var race = new BaseRace();
        race.AddEffect(new Effect(_character.StatsData.Strength, ModifierType.Flat) { Potency = 100f });
        _character.SetRace(race);
        Assert.That(_character.StatsData.Strength.Value, Is.EqualTo(100f));
    }
    
    [Test]
    public void AddEffect()
    {
        _character.AddEffect(new Effect(_character.StatsData.Strength, ModifierType.Flat) { Potency = 10f });
        Assert.That(_character.StatsData.Strength.Value, Is.EqualTo(10f));
    }
    
    [Test]
    public void RemoveEffect()
    {
        var effect = new Effect(_character.StatsData.Strength, ModifierType.Flat) { Potency = 10f };
        _character.AddEffect(effect);
        Assert.That(_character.RemoveEffect(effect), Is.True);
        Assert.That(_character.HasEffect(effect), Is.False);
    }
    
    [Test]
    public void HasEffect()
    {
        var effect = new Effect(_character.StatsData.Strength, ModifierType.Flat) { Potency = 10f };
        _character.AddEffect(effect);
        Assert.That(_character.HasEffect(effect), Is.True);
    }
    
    [Test]
    public void ClearEffects()
    {
        var effect = new Effect(_character.StatsData.Strength, ModifierType.Flat) { Potency = 10f };
        _character.AddEffect(effect);
        _character.ClearEffects();
        Assert.That(_character.HasEffect(effect), Is.False);
    }

    [Test]
    public void NewHasMultipleClasses()
    {
        var class1 = new BaseClass();
        var class2 = new BaseClass();
        
        var character = new Character(
            [class1, class2],
            new BaseRace(),
            []
        );
        
        class1.AddEffect(new Effect(character.StatsData.Strength, ModifierType.Flat) { Potency = 10f });
        class2.AddEffect(new Effect(character.StatsData.Strength, ModifierType.Flat) { Potency = 10f });
        
        Assert.That(character.StatsData.Strength.Value, Is.EqualTo(20f));
    }
}