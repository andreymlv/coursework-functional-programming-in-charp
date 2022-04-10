using Xunit;
using Library;
using System;

namespace Tests;

public class SqrtUnitTest
{
    [Theory]
    [InlineData(1, 1)]
    [InlineData(4, 2)]
    [InlineData(8, 2.828427)]
    public void RecursiveInvokeTest(double x, double expected)
    {
        var actual = Sqrt.RecursiveInvoke(x);
        Assert.True(Math.Abs(expected - actual) < Sqrt.Epsilon);
    }

    [Theory]
    [InlineData(1, 1)]
    [InlineData(4, 2)]
    [InlineData(8, 2.828427)]
    public void TailRecursiveInvokeTest(double x, double expected)
    {
        var actual = Sqrt.TailRecursiveInvoke(x);
        Assert.True(Math.Abs(expected - actual) < Sqrt.Epsilon);
    }

    [Theory]
    [InlineData(1, 1)]
    [InlineData(4, 2)]
    [InlineData(8, 2.828427)]
    public void FixedPointInvokeTest(double x, double expected)
    {
        var actual = Sqrt.FixedPointInvoke(x);
        Assert.True(Math.Abs(expected - actual) < Sqrt.Epsilon);
    }
}

