using System.Diagnostics;

int maxN = 1000;
int min = 0;
int max = 1000;
var randNum = new Random();
int[] numArray = Enumerable
    .Repeat(1, maxN)
    .Select(i => randNum.Next(min, max))
    .ToArray();

long[] timeSamples = new long[maxN];


for (int i = 0; i < maxN; i++)
{
  int N = randNum.Next(min, max);
  var dt = new DemoThread(numArray, N);
  long startTime = Stopwatch.GetTimestamp();
  Thread t = new Thread(new ThreadStart(dt.ThreadFunction));
  t.Start();
  t.Join();
  long endTime = Stopwatch.GetTimestamp();
  timeSamples[i] = endTime- startTime;
}

Console.WriteLine($"min: {timeSamples.Min()} μs , max: {timeSamples.Max()} μs , {Math.Round(timeSamples.Average(), 2)} μs , std dev {Math.Round(timeSamples.StandardDeviation())} μs ");

timeSamples = new long[maxN];

for (int i = 0; i < maxN; i++)
{
  int N = randNum.Next(min, max);
  var dt = new DemoThread(numArray, N);
  long startTime = Stopwatch.GetTimestamp();
  dt.ThreadFunction();
  long endTime = Stopwatch.GetTimestamp();
  timeSamples[i] = endTime- startTime;
}

Console.WriteLine($"min: {timeSamples.Min()} μs , max: {timeSamples.Max()} μs , {Math.Round(timeSamples.Average(), 2)} μs , std dev {Math.Round(timeSamples.StandardDeviation())} μs ");
