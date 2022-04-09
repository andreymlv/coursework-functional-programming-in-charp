using Xunit;
using Library;

namespace Tests;

public class SumUnitTest
{
    private static double Term(double x) => x;
    private static double Next(double x) => x + 1;

    [Theory]
    [InlineData(1, 1, 1)]
    [InlineData(1, 2, 3)]
    [InlineData(-5, 5, 0)]
    public void RecursiveInvokeTest(double from, double to, double expected)
    {
        var actual = Sum.Solve(Sequence.RecursiveInvoke, Term, from, Next, to);
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(1, 1, 1)]
    [InlineData(1, 2, 3)]
    [InlineData(-5, 5, 0)]
    public void TailRecursiveInvokeTest(double from, double to, double expected)
    {
        var actual = Sum.Solve(Sequence.TailRecursiveInvoke, Term, from, Next, to);
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(1, 1, 1)]
    [InlineData(1, 2, 3)]
    [InlineData(-5, 5, 0)]
    public void ImperativeInvokeTest(double from, double to, double expected)
    {
        var actual = Sum.Solve(Sequence.ImperativeInvoke, Term, from, Next, to);
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(1, 1, 1)]
    [InlineData(1, 2, 3)]
    [InlineData(-5, 5, 0)]
    public void DotNetInvokeTest(double from, double to, double expected)
    {
        var actual = Sum.Solve(Sequence.DotNetInvoke, Term, from, Next, to);
        Assert.Equal(expected, actual);
    }
}