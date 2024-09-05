using FlowerRpg.Combat;
using FlowerRpg.Fantasy.Classes;

namespace FlowerRpg.Fantasy.Combat;

public class BasicAttackProcessor : IAttackProcessor<CharacterStats>
{
    public ProcessedAttack ProcessAttack(Attack attack, CharacterStats defendingStats)
    {
        var defenseStats = defendingStats.GetDefenseStats();
        var damageStats = defendingStats.GetDamageStats().ToDictionary(x => x.StatType, x => x.Value);
        var resultingDefense = new List<Damage>();
        
        foreach (var defenseStat in defenseStats)
        {
            if (!damageStats.ContainsKey(defenseStat.StatType)) continue;
            float defendedValue;

            if (damageStats[defenseStat.StatType] > defenseStat.Value)
            {
                defendedValue = defenseStat.Value;
            }
            else
            {
                defendedValue = defenseStat.Value - damageStats[defenseStat.StatType];
            }
            
            damageStats[defenseStat.StatType] -= defenseStat.Value;

            resultingDefense.Add(new Damage
            {
                Type = defenseStat.StatType,
                Value = defendedValue
            });
        }
        
        var resultingDamage = damageStats
            .Select(x => new Damage(x.Key, x.Value));

        return new ProcessedAttack(resultingDamage.ToList(), resultingDefense);
    }
}