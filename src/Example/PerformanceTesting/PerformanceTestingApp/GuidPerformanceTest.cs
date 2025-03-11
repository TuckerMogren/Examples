using System;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

public class GuidPerformanceTest
{
    private Guid _guid;

    [GlobalSetup]
    public void Setup()
    {
        _guid = Guid.NewGuid();
    }

    [Benchmark]
    public string GuidToString()
    {
        return _guid.ToString();
    }

    [Benchmark]
    public Guid UseGuidDirectly()
    {
        return _guid;
    }
}

