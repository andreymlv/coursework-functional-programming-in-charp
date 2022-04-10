﻿using System;
using Library;
using Xunit;

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
        var actual = EquationSolver.FixedPointOfTransform(y => x / y, EquationSolver.AverageDampTransform, 1.0);
        Assert.True(Math.Abs(expected - actual) < Sqrt.Epsilon);
    }

    [Theory]
    [InlineData(1, 1)]
    [InlineData(4, 2)]
    [InlineData(8, 2.828427)]
    public void NewtonsMethodInvokeTest(double x, double expected)
    {
        var actual =
            EquationSolver.FixedPointOfTransform(y => Math.Pow(y, 2) - x, EquationSolver.NewtonsTransform, 1.0);
        Assert.True(Math.Abs(expected - actual) < Sqrt.Epsilon);
    }
}