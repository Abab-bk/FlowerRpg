using FlowerRpg.Stats;

namespace Tests;

public class StatTest
{
    private Stat _testStat;
    private Modifier _flatModifier;
    private Modifier _percentAddModifier;
    private Modifier _percentMultModifier;
    // applier: x = 1, value will be * 10
    // private Modifier _customModifier;
    
    [SetUp]
    public void Setup()
    {
        _testStat = new Stat(100);
        _flatModifier = new Modifier(10, ModifierType.Flat);
        _percentAddModifier = new Modifier(0.1f, ModifierType.PercentAdd);
        _percentMultModifier = new Modifier(0.2f, ModifierType.PercentMult);
        // _customModifier = new Modifier(1f,
        //     (stat, modifierValue) => modifierValue * 10
        //     );
    }

    [Test]
    public void AddFlatModifier_ModifierAdded()
    {
        _testStat.AddModifier(_flatModifier);
        Assert.That(_testStat.Value, Is.EqualTo(110));
    }
    
    [Test]
    public void AddPercentAddModifier_ModifierAdded()
    {
        _testStat.AddModifier(_percentAddModifier);
        Assert.That(_testStat.Value, Is.EqualTo(110));
    }
    
    [Test]
    public void AddPercentMultModifier_ModifierAdded()
    {
        _testStat.AddModifier(_percentMultModifier);
        Assert.That(_testStat.Value, Is.EqualTo(120));
    }
    
    // [Test]
    // public void AddCustomModifier_ModifierAdded()
    // {
    //     _testStat.AddModifier(_customModifier);
    //     Assert.That(_testStat.Value, Is.EqualTo(1000));
    // }


    [Test]
    public void AddModifier_NumbersOfModifiers_IncreaseByOne()
    {
        Assert.That(_testStat.Modifiers.Count, Is.EqualTo(0));
        _testStat.AddModifier(_flatModifier);
        Assert.That(_testStat.Modifiers.Count, Is.EqualTo(1));
    }
    
    [Test]
    public void RemoveAllModifiers_NumbersOfModifiers_IsZero()
    {
        Assert.That(_testStat.Modifiers.Count, Is.EqualTo(0));
        _testStat.AddModifier(_flatModifier);
        _testStat.RemoveAllModifiers();
        Assert.That(_testStat.Modifiers.Count, Is.EqualTo(0));
    }
    
    [Test]
    public void RemoveAllModifiersBySource_NumbersOfModifiers_IsZero()
    {
        _testStat.AddModifier(new Modifier(10, ModifierType.Flat, this));
        _testStat.RemoveAllModifiersFromSource(this);
        Assert.That(_testStat.Modifiers.Count, Is.EqualTo(0));
    }
    
    [Test]
    public void RemoveModifier_NumbersOfModifiers_DecreaseByOne()
    {
        _testStat.AddModifier(_flatModifier);
        Assert.That(_testStat.Modifiers.Count, Is.EqualTo(1));
        _testStat.RemoveModifier(_flatModifier);
        Assert.That(_testStat.Modifiers.Count, Is.EqualTo(0));
    }
}