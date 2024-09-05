using FlowerRpg.Fantasy.Characters;
using FlowerRpg.Fantasy.Combat;
using FlowerRpg.Fantasy.Races;

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