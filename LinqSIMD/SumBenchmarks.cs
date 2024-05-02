using BenchmarkDotNet.Attributes;

namespace LinqSIMD;

[MemoryDiagnoser(false)]
public class SumBenchmarks
{
    private static readonly int[] Numbers = Enumerable.Range(1, 100_000).ToArray();

    [Benchmark]
    public int SimpleLoop()
    {
        var result = 0;
        foreach (var number in Numbers)
        {
            result += number;
        }
        return result;
    }

    [Benchmark]
    public int SimpleLinq()
    {
        return Numbers.Sum();
    }

    [Benchmark]
    public int LinqSimd()
    {
        return SimdLinq.SimdLinqExtensions.Sum(Numbers);
    }



}

