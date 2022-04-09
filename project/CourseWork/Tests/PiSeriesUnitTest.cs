using Xunit;
using Library;
using System;
namespace Tests;

public class PiSeriesUnitTest
{
    private const double precition = 0.001;

    [Fact]
    public void RecursiveInvokeTest()
    {
        var actual = PiSeries.Solve(Sequence.RecursiveInvoke);
        Assert.True(Math.Abs(Math.PI - actual) < precition);
    }

    [Fact]
    public void TailRecursiveInvokeTest()
    {
        var actual = PiSeries.Solve(Sequence.TailRecursiveInvoke);
        Assert.True(Math.Abs(Math.PI - actual) < precition);
    }

    [Fact]
    public void ImperativeInvokeTest()
    {
        var actual = PiSeries.Solve(Sequence.ImperativeInvoke);
        Assert.True(Math.Abs(Math.PI - actual) < precition);
    }

    [Fact]
    public void DotNetInvokeTest()
    {
        var actual = PiSeries.Solve(Sequence.DotNetInvoke);
        Assert.True(Math.Abs(Math.PI - actual) < precition);
    }
}