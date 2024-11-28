using FlowerRpg.Stats;
using FlowerRpg.Stats.Modifiers;

namespace Tests;

public class StatTest
{
    private const float BaseValue = 100f;
    private Stat _stat;
    private Modifier _flatModifier;
    private Modifier _percentAddModifier;
    private Modifier _percentMultModifier;

    private CustomModifier _customModifier;

    private class CustomModifier : Modifier
    {
        public CustomModifier(float value, object source)
            : base(ModifierType.Flat, value, source)
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
        _stat = new Stat(BaseValue);
        _flatModifier = new Modifier(10, ModifierType.Flat);
        _percentAddModifier = new Modifier(0.1f, ModifierType.PercentAdd);
        _percentMultModifier = new Modifier(0.2f, ModifierType.PercentMult);
        _customModifier = new CustomModifier(10f);
    }

    [Test]
    public void AddFlatModifier_ModifierAdded()
    {
        _stat.AddModifier(_flatModifier);
        Assert.That(_stat.Value, Is.EqualTo(110));
    }

    [Test]
    public void AddPercentAddModifier_ModifierAdded()
    {
        _stat.AddModifier(_percentAddModifier);
        Assert.That(_stat.Value, Is.EqualTo(110));
    }

    [Test]
    public void AddPercentMultModifier_ModifierAdded()
    {
        _stat.AddModifier(_percentMultModifier);
        Assert.That(_stat.Value, Is.EqualTo(120));
    }

    [Test]
    public void AddCustomModifier_ModifierAdded()
    {
        _stat.AddModifier(_customModifier);
        Assert.That(_stat.Value, Is.EqualTo(200f));
    }


    [Test]
    public void AddModifier_NumbersOfModifiers_IncreaseByOne()
    {
        Assert.That(_stat.Modifiers.Count, Is.EqualTo(0));
        _stat.AddModifier(_flatModifier);
        Assert.That(_stat.Modifiers.Count, Is.EqualTo(1));
    }

    [Test]
    public void RemoveAllModifiers_NumbersOfModifiers_IsZero()
    {
        Assert.That(_stat.Modifiers.Count, Is.EqualTo(0));
        _stat.AddModifier(_flatModifier);
        _stat.RemoveAllModifiers();
        Assert.That(_stat.Modifiers.Count, Is.EqualTo(0));
    }

    [Test]
    public void RemoveAllModifiersBySource_NumbersOfModifiers_IsZero()
    {
        _stat.AddModifier(new Modifier(ModifierType.Flat, 10, this));
        _stat.RemoveAllModifiersFromSource(this);
        Assert.That(_stat.Modifiers.Count, Is.EqualTo(0));
    }

    [Test]
    public void RemoveModifier_NumbersOfModifiers_DecreaseByOne()
    {
        _stat.AddModifier(_flatModifier);
        Assert.That(_stat.Modifiers.Count, Is.EqualTo(1));
        _stat.RemoveModifier(_flatModifier);
        Assert.That(_stat.Modifiers.Count, Is.EqualTo(0));
    }

    [Test]
    public void GetValue_ShouldReturnBaseValue_WhenNoModifiers()
    {
        Assert.That(_stat.Value, Is.EqualTo(BaseValue));
    }

    [Test]
    public void AddModifier_ShouldAddModifier_AndReturnTrue()
    {
        var modifier = new Modifier(ModifierType.Flat, 10, 1);

        var result = _stat.AddModifier(modifier);

        Assert.IsTrue(result);
        Assert.IsTrue(_stat.HasModifier(modifier));
    }

    [Test]
    public void AddModifier_ShouldReturnFalse_WhenModifierIsNull()
    {
        var result = _stat.AddModifier(null);

        Assert.IsFalse(result);
    }

    [Test]
    public void RemoveModifier_ShouldRemoveModifier_AndReturnTrue()
    {
        var modifier = new Modifier(ModifierType.Flat, 10, 1);
        _stat.AddModifier(modifier);

        var result = _stat.RemoveModifier(modifier);

        Assert.IsTrue(result);
        Assert.IsFalse(_stat.HasModifier(modifier));
    }

    [Test]
    public void RemoveModifier_ShouldReturnFalse_WhenModifierDoesNotExist()
    {
        var modifier = new Modifier(ModifierType.Flat, 10, 1);

        var result = _stat.RemoveModifier(modifier);

        Assert.IsFalse(result);
    }

    [Test]
    public void RemoveAllModifiers_ShouldClearModifiers()
    {
        var modifier = new Modifier(ModifierType.Flat, 10, 1);
        _stat.AddModifier(modifier);

        _stat.RemoveAllModifiers();

        Assert.IsFalse(_stat.HasModifier(modifier));
    }

    [Test]
    public void RemoveAllModifiersFromSource_ShouldRemoveSpecificSourceModifiers()
    {
        var source = new object();
        var modifier1 = new Modifier(ModifierType.Flat, 10, 1, source);
        var modifier2 = new Modifier(ModifierType.PercentAdd, 0.1f, 2);
        _stat.AddModifier(modifier1);
        _stat.AddModifier(modifier2);

        _stat.RemoveAllModifiersFromSource(source);

        Assert.IsFalse(_stat.HasModifier(modifier1));
        Assert.IsTrue(_stat.HasModifier(modifier2));
    }

    [Test]
    public void Value_ShouldRecalculate_WhenModifiersChange()
    {
        var modifier = new Modifier(ModifierType.Flat, 10, 1);
        var modifier2 = new Modifier(ModifierType.PercentAdd, 0.1f, 2);
        _stat.AddModifier(modifier);
        _stat.AddModifier(modifier2);

        var expectedResult = (BaseValue + 10) * (1 + 0.1f);
        Assert.That(expectedResult, Is.EqualTo(_stat.Value));
    }

    [Test]
    public void Value_ShouldRaiseOnValueChangedEvent_WhenValueChanges()
    {
        var onValueChangedCalled = false;
        _stat.OnValueChanged = _ => onValueChangedCalled = true;

        var modifier = new Modifier(ModifierType.Flat, 10, 1);
        _stat.AddModifier(modifier);

        var _ = _stat.Value; // Trigger the calculation and event Assert.IsTrue(onValueChangedCalled);
    }

    [Test]
    public void Modifiers_ShouldBeSortedByOrder()
    {
        var modifier1 = new Modifier(ModifierType.Flat, 10, 2);
        var modifier2 = new Modifier(ModifierType.Flat, 5, 1);
        _stat.AddModifier(modifier1);
        _stat.AddModifier(modifier2);

        var modifiers = _stat.GetModifiers();
        var modifiersList = new List<Modifier>(modifiers);

        Assert.That(modifier2, Is.EqualTo(modifiersList[0]));
        Assert.That(modifier1, Is.EqualTo(modifiersList[1]));
    }
}