# Benchmark Analysis

* Throw an exception vs return Result type (FluentResult) benchmark

|                  Method | Iterations |        Mean |      Error |     StdDev | Allocated |
|------------------------ |----------- |------------:|-----------:|-----------:|----------:|
|   Faiil_UsingExceptions |       1000 | 9,008.20 us | 166.171 us | 354.125 us | 335.95 KB |
|   Faiil_UsingResultType |       1000 |   479.98 us |   8.027 us |   7.508 us | 656.25 KB |
| Success_UsingExceptions |       1000 |    34.03 us |   0.652 us |   0.578 us |  78.13 KB |
| Success_UsingResultType |       1000 |   268.75 us |   5.072 us |   4.982 us | 421.88 KB |

* ...
