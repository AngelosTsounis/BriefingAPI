public class ApiStats
{
    public int TotalRequests { get; set; }
    public long TotalDurationMs { get; set; }
    public int FastCount { get; set; }    // < 100ms
    public int AverageCount { get; set; } // 100–200ms
    public int SlowCount { get; set; }    // > 200ms
    public double AverageResponseTime => TotalRequests == 0 ? 0 : (double)TotalDurationMs / TotalRequests;
}

