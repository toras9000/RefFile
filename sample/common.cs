#:package Humanizer.Core@3.0.1
// File-based directives within referenced files will be deleted.
using Humanizer;

public record CommonData(long Value)
{
    public void Print() => Console.WriteLine(this.Value.ToMetric(decimals: 2));
}