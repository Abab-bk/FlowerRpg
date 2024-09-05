using FlowerRpg.Fantasy.Classes.Affixes;
using FlowerRpg.Fantasy.Classes.Characters;
using FlowerRpg.Fantasy.Classes.Races;
using FlowerRpg.Fantasy.Inventory;

namespace Tests;

public class EquipmentTest
{
    private Character _character;
    
    [SetUp]
    public void Setup()
    {
        _character = new Character([], new BaseRace(), []);
    }
    
    [Test]
    public void Equip_And_Release()
    {
        var equipment = new Equipment(new ItemTemplate())
        {
            Affixes = [new SimpleAffix()
            {
                TargetStat = _character.StatsData.Strength,
                Values = [10f]
            }]
        };
        Assert.That(_character.StatsData.Strength.Value, Is.EqualTo(0f));
        equipment.Equip(_character.StatsData);
        Assert.That(_character.StatsData.Strength.Value, Is.EqualTo(10f));
        equipment.Release(_character.StatsData);
        Assert.That(_character.StatsData.Strength.Value, Is.EqualTo(0f));
    }

    [Test]
    public void Activating_Add_And_Remove_Affix()
    {
        var equipment = new Equipment(new ItemTemplate())
        {
            Affixes =
            [
                new SimpleAffix()
                {
                    TargetStat = _character.StatsData.Strength,
                    Values = [10f]
                }
            ]
        };
        equipment.Equip(_character.StatsData);
        
        Assert.That(_character.StatsData.Strength.Value, Is.EqualTo(10f));

        var affix = new SimpleAffix()
        {
            TargetStat = _character.StatsData.Strength,
            Values = [20f]
        };
        equipment.AddAffix(affix, _character.StatsData);
        
        Assert.That(_character.StatsData.Strength.Value, Is.EqualTo(30f));
        
        equipment.RemoveAffix(affix, _character.StatsData);
        
        Assert.That(_character.StatsData.Strength.Value, Is.EqualTo(10f));
    }
}