internal static class StatisticExtensions
{
  public static double StandardDeviation(this IEnumerable<long> values)
  {
    double avg = values.Average();
    return Math.Sqrt(values.Average(v => Math.Pow(v - avg, 2)));
  }
}