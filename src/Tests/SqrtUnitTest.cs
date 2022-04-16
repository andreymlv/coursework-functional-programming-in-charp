using System;
using Library;
using Xunit;

namespace Tests;

public class SqrtUnitTest
{
    [Theory]
    [InlineData(1, 1)]
    [InlineData(4, 2)]
    [InlineData(8, 2.828427)]
    [InlineData(16, 4)]
    [InlineData(132172371237, 363555.1832074465)]
    [InlineData(int.MaxValue, 46340.95000105199)]
    public void RecursiveInvokeTest(double x, double expected)
    {
        var actual = Sqrt.RecursiveInvoke(x);
        Assert.True(Math.Abs(expected - actual) < Sqrt.Epsilon);
    }

    [Theory]
    [InlineData(1, 1)]
    [InlineData(4, 2)]
    [InlineData(8, 2.828427)]
    [InlineData(16, 4)]
    [InlineData(132172371237, 363555.1832074465)]
    [InlineData(int.MaxValue, 46340.95000105199)]
    public void TailRecursiveInvokeTest(double x, double expected)
    {
        var actual = Sqrt.TailRecursiveInvoke(x);
        Assert.True(Math.Abs(expected - actual) < Sqrt.Epsilon);
    }

    [Theory]
    [InlineData(1, 1)]
    [InlineData(4, 2)]
    [InlineData(8, 2.828427)]
    [InlineData(16, 4)]
    [InlineData(132172371237, 363555.1832074465)]
    [InlineData(int.MaxValue, 46340.95000105199)]
    public void FixedPointInvokeTest(double x, double expected)
    {
        var actual = EquationSolver.FixedPointOfTransform(y => x / y, EquationSolver.AverageDampTransform, 1.0);
        Assert.True(Math.Abs(expected - actual) < Sqrt.Epsilon);
    }

    [Theory]
    [InlineData(1, 1)]
    [InlineData(4, 2)]
    [InlineData(8, 2.828427)]
    [InlineData(16, 4)]
    [InlineData(132172371237, 363555.1832074465)]
    [InlineData(int.MaxValue, 46340.95000105199)]
    public void NewtonsMethodInvokeTest(double x, double expected)
    {
        var actual =
            EquationSolver.FixedPointOfTransform(y => Math.Pow(y, 2) - x, EquationSolver.NewtonsTransform, 1.0);
        Assert.True(Math.Abs(expected - actual) < Sqrt.Epsilon);
    }
}