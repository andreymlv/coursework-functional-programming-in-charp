namespace Library;

public static class PiSeries
{
    private static double Term(double x)
    {
        return 1.0d / (x * (x + 2));
    }

    private static double Next(double x)
    {
        return x + 4;
    }

    public static double Solve(
        Func<Func<double, double, double>, Func<double, double>, double, Func<double, double>, double, double, double>
            strategy)
    {
        return 8 * Sum.Solve(strategy, Term, 1, Next, 10000);
    }
}