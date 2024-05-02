// See https://aka.ms/new-console-template for more information
// References
// Nick Chapsas: https://www.youtube.com/watch?v=5JKhNV9TY8k
// GitHub: https://github.com/Cysharp/SimdLinq?tab=readme-ov-file
// Some reading: https://steven-giesel.com/blogPost/faf06188-bae9-484d-804d-a42d58d18cad
// For those who are interested what's under the hood: https://www.youtube.com/watch?v=wPT6iu3MZP0&t=32s

using BenchmarkDotNet.Running;
using LinqSIMD;

BenchmarkRunner.Run<SumBenchmarks>();
BenchmarkRunner.Run<AverageBenchmarks>();
BenchmarkRunner.Run<MaxBenchmarks>();
BenchmarkRunner.Run<ContainsBenchmarks>();
