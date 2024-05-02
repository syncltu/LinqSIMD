using System.Data.SqlTypes;
using BenchmarkDotNet.Attributes;

namespace LinqSIMD;

[MemoryDiagnoser(false)]
public class ContainsBenchmarks
{
    private const int SearchableInt = 10_0001;
    private static readonly int[] Numbers = Enumerable.Range(1, 1000_000).ToArray();

    [Benchmark]
    public bool SimpleLoop()
    {
        foreach (var number in Numbers)
        {
            if (number==SearchableInt)
            {
                return true;
            }
        }

        return false;
    }

    [Benchmark]
    public bool Linq()
    {
        return Numbers.Contains(SearchableInt);
    }

    [Benchmark]
    public bool LinqSimd()
    {
        return SimdLinq.SimdLinqExtensions.Contains(Numbers,SearchableInt);
    }

}

