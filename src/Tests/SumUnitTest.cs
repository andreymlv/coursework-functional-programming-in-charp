using Library;
using Xunit;

namespace Tests;

public class SumUnitTest
{
    private static double Term(double x)
    {
        return x;
    }

    private static double Next(double x)
    {
        return x + 1;
    }

    [Theory]
    [InlineData(1, 1, 1)]
    [InlineData(1, 2, 3)]
    [InlineData(-5, 5, 0)]
    [InlineData(1, 10, 55)]
    public void RecursiveInvokeTest(double from, double to, double expected)
    {
        var actual = Sum.Solve(Accumulate.RecursiveInvoke, Term, from, Next, to);
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(1, 1, 1)]
    [InlineData(1, 2, 3)]
    [InlineData(-5, 5, 0)]
    [InlineData(1, 10, 55)]
    public void TailRecursiveInvokeTest(double from, double to, double expected)
    {
        var actual = Sum.Solve(Accumulate.TailRecursiveInvoke, Term, from, Next, to);
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(1, 1, 1)]
    [InlineData(1, 2, 3)]
    [InlineData(-5, 5, 0)]
    [InlineData(1, 10, 55)]
    public void ImperativeInvokeTest(double from, double to, double expected)
    {
        var actual = Sum.Solve(Accumulate.ImperativeInvoke, Term, from, Next, to);
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(1, 1, 1)]
    [InlineData(1, 2, 3)]
    [InlineData(-5, 5, 0)]
    [InlineData(1, 10, 55)]
    public void DotNetInvokeTest(double from, double to, double expected)
    {
        var actual = Sum.Solve(Accumulate.DotNetInvoke, Term, from, Next, to);
        Assert.Equal(expected, actual);
    }
}