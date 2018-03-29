
# Problem 12 Benchmarks

### Description

> Highly divisible triangular number
>
> The sequence of triangle numbers is generated by adding the natural numbers. So the 7th triangle number would be 1 + 2 + 3 + 4 + 5 + 6 + 7 = 28. The first ten terms would be:
>
> 1, 3, 6, 10, 15, 21, 28, 36, 45, 55, ...
>
> Let us list the factors of the first seven triangle numbers:
>
> 1: 1
> 3: 1,3
> 6: 1,2,3,6
> 10: 1,2,5,10
> 15: 1,3,5,15
> 21: 1,3,7,21
> 28: 1,2,4,7,14,28
>
> We can see that 28 is the first triangle number to have over five divisors.
>
> What is the value of the first triangle number to have over five hundred divisors?

For the purposes of the benchmark, we're looking for the first triangular number
with over 1000 divisors.

Using the same algorithm, with the data structures available in their
standard library, compare the performance of this problem as written in C++, Java,
C#, Go, Rust, F#, and Scala. Note that no special language-specific tuning is evident.
I wrote this code is as if I were a naive rookie for each language (which I am).
Full optimizing flags were passed to the language's compiler for those languages that have them.

### Results

Below is a table of summarized results from a particular run. `/usr/bin/time -v` is used
for the benchmark. From `/usr/bin/time -v`, the column header of `Time` is seconds from `Elapsed (wall clock) time (m:ss)`,
`Max-mem` is `Maximum resident set size (kbytes)`, `%CPU` is `Percent of CPU this job got`,
`Vol` is `Voluntary context switches`, and `Invol` is `Involuntary context switches`.
`C# AOT` is compiled and ran with [CoreRT](https://github.com/dotnet/corert).

| Language | Time | Max-mem | %CPU |  Vol | Invol |
| ------   | ---- | ------- | ---- | ---- | ----- |
| Rust     |  9.7 |  761948 |   99 |    3 |    19 |
| C#       | 10.3 | 1223508 |  102 |  118 |   303 |
| C# AOT   | 10.3 |  919788 |   99 |   12 |    18 |
| Swift    | 10.6 |  417532 |   99 |    3 |    26 |
| Crystal  | 11.0 | 1417640 |   99 |  304 |   324 |
| Go       | 11.4 |  387552 |  103 | 1539 |   138 |
| F#       | 12.2 |  973736 |  106 |   95 |   279 |
| C++      | 14.5 | 1053204 |  100 |    1 |    27 |
| Scala    | 20.8 | 1464376 |  175 | 2363 |  3884 |
| Java     | 21.6 | 1586532 |  250 | 2091 |  6883 |

