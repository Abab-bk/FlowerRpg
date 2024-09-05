using FlowerRpg.Fantasy.Classes.Characters;
using FlowerRpg.Fantasy.Classes.Races;
using FlowerRpg.Fantasy.Combat;

namespace Tests;

public class AttackProcessorTest
{
    [SetUp]
    public void Setup()
    {
    }
    
    [Test]
    public void ProcessAttack()
    {
        var player = new Character([], new BaseRace(), []);
        var mob = new Character([], new BaseRace(), []);

        var processedAttack =
            new BasicAttackProcessor()
                .ProcessAttack(
                    new BasicAttackGenerator().GenerateAttack(player.StatsData),
                    mob.StatsData
                    );
        
        Assert.That(processedAttack.DamageDone.First().Value, Is.EqualTo(1f));
    }
}