```

BenchmarkDotNet v0.13.12, Windows 10 (10.0.19045.4529/22H2/2022Update)
Intel Xeon W-11955M CPU 2.60GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 8.0.300
  [Host]     : .NET 8.0.5 (8.0.524.21615), X64 RyuJIT AVX-512F+CD+BW+DQ+VL+VBMI
  DefaultJob : .NET 8.0.5 (8.0.524.21615), X64 RyuJIT AVX-512F+CD+BW+DQ+VL+VBMI


```
| Method                              | Mean       | Error      | StdDev     | Ratio | RatioSD | Rank | Gen0   | Allocated | Alloc Ratio |
|------------------------------------ |-----------:|-----------:|-----------:|------:|--------:|-----:|-------:|----------:|------------:|
| GetYearFromSpanWithManualConversion |   7.156 ns |  0.0878 ns |  0.0822 ns |  0.04 |    0.00 |    1 |      - |         - |          NA |
| GetYearFromSpan                     |  11.245 ns |  0.1104 ns |  0.0978 ns |  0.06 |    0.00 |    2 |      - |         - |          NA |
| GetYearFromSplit                    |  50.123 ns |  1.4912 ns |  4.3969 ns |  0.28 |    0.01 |    3 | 0.0127 |     160 B |          NA |
| GetYearFromDateTime                 | 195.987 ns |  3.8398 ns |  4.2680 ns |  1.00 |    0.00 |    4 |      - |         - |          NA |
| GetYearFromSubstring                | 984.476 ns | 13.7273 ns | 12.8405 ns |  5.03 |    0.13 |    5 | 0.0019 |      32 B |          NA |
