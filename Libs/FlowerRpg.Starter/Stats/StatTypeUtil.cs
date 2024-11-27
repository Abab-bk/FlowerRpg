namespace FlowerRpg.Starter.Stats;

public static class StatTypeUtil
{
    public static bool IsVital(StatType statType) =>
        statType == StatType.Health;

    public static int GetVitalCount()
    {
        int count = 0;
        foreach (StatType statType in Enum.GetValues(typeof(StatType)))
        {
            if (IsVital(statType)) count++;
        }
        return count;
    }
    
    public static int GetStatCount()
    {
        int count = 0;
        foreach (StatType statType in Enum.GetValues(typeof(StatType)))
        {
            if (!IsVital(statType)) count++;
        }
        return count;
    }
}