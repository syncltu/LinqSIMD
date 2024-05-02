using BenchmarkDotNet.Attributes;

namespace LinqSIMD;

[MemoryDiagnoser(false)]
public class MaxBenchmarks
{
    private static readonly Random rng = new();
    private static readonly int[] Numbers = Enumerable.Range(1, 1000_000).Select(_ => rng.Next()).ToArray();

    [Benchmark]
    public int SimpleLoop()
    {
        var result = 0;
        foreach (var number in Numbers)
        {
            if (number>result)
            {
                result = number;
            }
        }
        return result;
    }

    [Benchmark]
    public int Linq()
    {
        return Numbers.Max();
    }

    [Benchmark]
    public (int min,int max) LinqSimd()
    {
        return SimdLinq.SimdLinqExtensions.MinMax(Numbers);
    }

}

