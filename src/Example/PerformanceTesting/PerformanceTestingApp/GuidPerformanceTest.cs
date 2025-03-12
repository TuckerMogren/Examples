using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

public class GuidPerformanceTest
{
    private Guid _guid;
    private static List<Guid> _guidList = new();

    private string _string;
    private static List<string> _stringList = new();

    [GlobalSetup]
    public void Setup()
    {
        _guid = Guid.NewGuid();
    }

    [Benchmark]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public string GuidToString()
    {
        var str = _guid.ToString();
        _stringList.Add(str);
        return str;
    }

    [Benchmark]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Guid UseGuidDirectly()
    {
        _guidList.Add(_guid);
        return _guid;
    }
}
