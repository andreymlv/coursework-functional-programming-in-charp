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
}