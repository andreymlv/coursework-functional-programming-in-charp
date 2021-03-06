using System;
using Library;
using Xunit;

namespace Tests;

public class EquationSolverUnitTest
{
    private const double Epsilon = 0.001;

    [Fact]
    public void HalfIntervalSinPiTest()
    {
        var actual = EquationSolver.HalfIntervalMethod(Math.Sin, 2.0, 4.0);
        Assert.True(Math.Abs(Math.PI - actual) < Epsilon);
    }

    [Fact]
    public void HalfIntervalEquationTest()
    {
        static double Equation(double x)
        {
            return Math.Pow(x, 3) - 2 * x - 3;
        }

        var actual = EquationSolver.HalfIntervalMethod(Equation, 1.0, 2.0);
        Assert.True(Math.Abs(1.8933 - actual) < Epsilon);
    }

    [Fact]
    public void NewtonsSinEquationTest()
    {
        var actual = EquationSolver.FixedPointOfTransform(Math.Sin, EquationSolver.NewtonsTransform, 3.0);
        Assert.True(Math.Abs(Math.PI - actual) < Epsilon);
    }

    [Fact]
    public void NewtonsEquationTest()
    {
        static double Equation(double x)
        {
            return Math.Pow(x, 3) - 2 * x - 3;
        }

        var actual = EquationSolver.FixedPointOfTransform(Equation, EquationSolver.NewtonsTransform, 1.0);
        Assert.True(Math.Abs(1.8933 - actual) < Epsilon);
    }
}