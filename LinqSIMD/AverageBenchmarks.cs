using BenchmarkDotNet.Attributes;

namespace LinqSIMD;

[MemoryDiagnoser(false)]
public class AverageBenchmarks
{
    private static readonly Random rng = new();
    private static readonly int[] Numbers = Enumerable.Range(1, 1000_000).Select(_ => rng.Next()).ToArray();

    [Benchmark]
    public double SimpleLoop()
    {
        var sum = 0;
        foreach (var number in Numbers)
        {
            sum += number;
        }

        return (double)sum / Numbers.Length;
    }

    [Benchmark]
    public double Linq()
    {
        return Numbers.Average();
    }

    [Benchmark]
    public double LinqSimd()
    {
        return SimdLinq.SimdLinqExtensions.Average(Numbers);
    }

}

