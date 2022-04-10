using Xunit;
using Library;
using System;

namespace Tests;

public class EquationSolverUnitTest
{
    private const double precition = 0.001;

    [Fact]
    public void HalfIntervalSinPiTest()
    {
        var actual = EquationSolver.HalfIntervalMethod(Math.Sin, 2.0, 4.0);
        Assert.True(Math.Abs(Math.PI - actual) < precition);
    }

    [Fact]
    public void HalfIntervalEquationTest()
    {
        static double eq(double x) => Math.Pow(x, 3) - 2 * x - 3;
        var actual = EquationSolver.HalfIntervalMethod(eq, 1.0, 2.0);
        Assert.True(Math.Abs(1.8933 - actual) < precition);
    }

    [Fact]
    public void FixedPointCos()
    {
        var actual = EquationSolver.FixedPoint(Math.Cos, 1.0);
        Assert.True(Math.Abs(0.739085 - actual) < precition);
    }
}