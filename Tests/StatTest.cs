using FlowerRpg.Stats;
using FlowerRpg.Stats.Modifiers;

namespace Tests;

public class StatTest
{
    private Stat _testStat;
    private Modifier _flatModifier;
    private Modifier _percentAddModifier;
    private Modifier _percentMultModifier;
    
    private CustomModifier _customModifier;
    
    private class CustomModifier : Modifier
    {
        public CustomModifier(float value, object source)
            : base(value, ModifierType.Flat, source)
        {
        }

        public CustomModifier(float value, int order = 0, object source = null)
            : base(value, ModifierType.Flat, order, source)
        {
        }

        public override float GetValue(float baseValue)
        {
            return Value * 10;
        }
    }
    
    [SetUp]
    public void Setup()
    {
        _testStat = new Stat(100);
        _flatModifier = new Modifier(10, ModifierType.Flat);
        _percentAddModifier = new Modifier(0.1f, ModifierType.PercentAdd);
        _percentMultModifier = new Modifier(0.2f, ModifierType.PercentMult);
        _customModifier = new CustomModifier(10f);
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
    
    [Test]
    public void AddCustomModifier_ModifierAdded()
    {
        _testStat.AddModifier(_customModifier);
        Assert.That(_testStat.Value, Is.EqualTo(200f));
    }


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