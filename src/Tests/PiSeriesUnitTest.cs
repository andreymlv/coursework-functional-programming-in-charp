using System;
using Library;
using Xunit;

namespace Tests;

public class PiSeriesUnitTest
{
    private const double Epsilon = 0.001;

    [Fact]
    public void RecursiveInvokeTest()
    {
        var actual = PiSeries.Solve(Accumulate.RecursiveInvoke);
        Assert.True(Math.Abs(Math.PI - actual) < Epsilon);
    }

    [Fact]
    public void TailRecursiveInvokeTest()
    {
        var actual = PiSeries.Solve(Accumulate.TailRecursiveInvoke);
        Assert.True(Math.Abs(Math.PI - actual) < Epsilon);
    }

    [Fact]
    public void ImperativeInvokeTest()
    {
        var actual = PiSeries.Solve(Accumulate.ImperativeInvoke);
        Assert.True(Math.Abs(Math.PI - actual) < Epsilon);
    }

    [Fact]
    public void DotNetInvokeTest()
    {
        var actual = PiSeries.Solve(Accumulate.DotNetInvoke);
        Assert.True(Math.Abs(Math.PI - actual) < Epsilon);
    }
}