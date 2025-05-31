namespace ApiAggregator.Services;

public static class PerformanceStore
{
    public static readonly Dictionary<string, ApiStats> Stats = new();
    private static readonly object LockObj = new();

    public static void Record(string apiName, long durationMs)
    {
        lock (LockObj)
        {
            if (!Stats.TryGetValue(apiName, out var stat))
            {
                stat = new ApiStats();
                Stats[apiName] = stat;
            }

            stat.TotalRequests++;
            stat.TotalDurationMs += durationMs;

            if (durationMs < 100)
                stat.FastCount++;
            else if (durationMs <= 200)
                stat.AverageCount++;
            else
                stat.SlowCount++;
        }
    }
    public static Dictionary<string, ApiStats> GetAllStats() => Stats;
}
